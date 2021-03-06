﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class ScrollSnapRect : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{


    public int startingPage = 0;
    public float fastSwipeThresholdTime = 0.3f;
    public int fastSwipeThresholdDistance = 100;
    public float decelerationRate = 10f;
    public Transform pageSelectionIcons;


    private int _fastSwipeThresholdMaxLimit;

    private ScrollRect _scrollRectComponent;
    private RectTransform _scrollRectRect;
    private RectTransform _container;

    private bool _horizontal;


    private int _pageCount;
    private int _currentPage;


    private bool _lerp;
    private Vector2 _lerpTo;


    private List<Vector2> _pagePositions = new List<Vector2>();


    private bool _dragging;
    private float _timeStamp;
    private Vector2 _startPosition;


    private bool _showPageSelection;
    private int _previousPageSelectionIndex;

    private List<Image> _pageSelectionImages;


    void Start()
    {
        _scrollRectComponent = GetComponent<ScrollRect>();
        _scrollRectRect = GetComponent<RectTransform>();
        _container = _scrollRectComponent.content;
        _pageCount = _container.childCount;


        if (_scrollRectComponent.horizontal && !_scrollRectComponent.vertical)
        {
            _horizontal = true;
        }
        else if (!_scrollRectComponent.horizontal && _scrollRectComponent.vertical)
        {
            _horizontal = false;
        }
        else
        {
            Debug.LogWarning("Confusing setting of horizontal/vertical direction. Default set to horizontal.");
            _horizontal = true;
        }

        _lerp = false;


        SetPagePositions();
        SetPage(startingPage);
        InitPageSelection();
        SetPageSelection(startingPage);



    }


    void Update()
    {

        if (_lerp)
        {

            float decelerate = Mathf.Min(decelerationRate * Time.deltaTime, 1f);
            _container.anchoredPosition = Vector2.Lerp(_container.anchoredPosition, _lerpTo, decelerate);

            if (Vector2.SqrMagnitude(_container.anchoredPosition - _lerpTo) < 0.25f)
            {

                _container.anchoredPosition = _lerpTo;
                _lerp = false;

                _scrollRectComponent.velocity = Vector2.zero;
            }


            if (_showPageSelection)
            {
                SetPageSelection(GetNearestPage());
            }
        }
    }


    private void SetPagePositions()
    {
        int width = 0;
        int height = 0;
        int offsetX = 0;
        int offsetY = 0;
        int containerWidth = 0;
        int containerHeight = 0;

        if (_horizontal)
        {

            width = (int)_scrollRectRect.rect.width;

            offsetX = width / 2;

            containerWidth = width * _pageCount;

            _fastSwipeThresholdMaxLimit = width;
        }
        else
        {
            height = (int)_scrollRectRect.rect.height;
            offsetY = height / 2;
            containerHeight = height * _pageCount;
            _fastSwipeThresholdMaxLimit = height;
        }


        Vector2 newSize = new Vector2(containerWidth, containerHeight);
        _container.sizeDelta = newSize;
        Vector2 newPosition = new Vector2(containerWidth / 2, containerHeight / 2);
        _container.anchoredPosition = newPosition;


        _pagePositions.Clear();


        for (int i = 0; i < _pageCount; i++)
        {
            RectTransform child = _container.GetChild(i).GetComponent<RectTransform>();
            Vector2 childPosition;
            if (_horizontal)
            {
                childPosition = new Vector2(i * width - containerWidth / 2 + offsetX, 0f);
            }
            else
            {
                childPosition = new Vector2(0f, -(i * height - containerHeight / 2 + offsetY));
            }
            child.anchoredPosition = childPosition;
            _pagePositions.Add(-childPosition);
        }
    }


    private void SetPage(int aPageIndex)
    {
        aPageIndex = Mathf.Clamp(aPageIndex, 0, _pageCount - 1);
        _container.anchoredPosition = _pagePositions[aPageIndex];
        _currentPage = aPageIndex;
    }


    private void LerpToPage(int aPageIndex)
    {
        aPageIndex = Mathf.Clamp(aPageIndex, 0, _pageCount - 1);
        _lerpTo = _pagePositions[aPageIndex];
        _lerp = true;
        _currentPage = aPageIndex;
    }


    private void InitPageSelection()
    {


        if (_showPageSelection)
        {

            if (pageSelectionIcons == null || pageSelectionIcons.childCount != _pageCount)
            {
                Debug.LogWarning("Different count of pages and selection icons - will not show page selection");
                _showPageSelection = false;
            }
            else
            {
                _previousPageSelectionIndex = -1;
                _pageSelectionImages = new List<Image>();


                for (int i = 0; i < pageSelectionIcons.childCount; i++)
                {
                    Image image = pageSelectionIcons.GetChild(i).GetComponent<Image>();
                    if (image == null)
                    {
                        Debug.LogWarning("Page selection icon at position " + i + " is missing Image component");
                    }
                    _pageSelectionImages.Add(image);
                }
            }
        }
    }


    private void SetPageSelection(int aPageIndex)
    {

        if (_previousPageSelectionIndex == aPageIndex)
        {
            return;
        }


        if (_previousPageSelectionIndex >= 0)
        {

            _pageSelectionImages[_previousPageSelectionIndex].SetNativeSize();
        }



        _pageSelectionImages[aPageIndex].SetNativeSize();

        _previousPageSelectionIndex = aPageIndex;
    }


    private void NextScreen()
    {
        LerpToPage(_currentPage + 1);
    }


    private void PreviousScreen()
    {
        LerpToPage(_currentPage - 1);
    }


    private int GetNearestPage()
    {

        Vector2 currentPosition = _container.anchoredPosition;

        float distance = float.MaxValue;
        int nearestPage = _currentPage;

        for (int i = 0; i < _pagePositions.Count; i++)
        {
            float testDist = Vector2.SqrMagnitude(currentPosition - _pagePositions[i]);
            if (testDist < distance)
            {
                distance = testDist;
                nearestPage = i;
            }
        }

        return nearestPage;
    }


    public void OnBeginDrag(PointerEventData aEventData)
    {

        _lerp = false;

        _dragging = false;
    }


    public void OnEndDrag(PointerEventData aEventData)
    {

        float difference;
        if (_horizontal)
        {
            difference = _startPosition.x - _container.anchoredPosition.x;
        }
        else
        {
            difference = -(_startPosition.y - _container.anchoredPosition.y);
        }


        if (Time.unscaledTime - _timeStamp < fastSwipeThresholdTime &&
            Mathf.Abs(difference) > fastSwipeThresholdDistance &&
            Mathf.Abs(difference) < _fastSwipeThresholdMaxLimit)
        {
            if (difference > 0)
            {
                NextScreen();
            }
            else
            {
                PreviousScreen();
            }
        }
        else
        {

            LerpToPage(GetNearestPage());
        }

        _dragging = false;
    }


    public void OnDrag(PointerEventData aEventData)
    {
        if (!_dragging)
        {

            _dragging = true;

            _timeStamp = Time.unscaledTime;

            _startPosition = _container.anchoredPosition;
        }
        else
        {
            if (_showPageSelection)
            {
                SetPageSelection(GetNearestPage());
            }
        }
    }

    public void OnShop()
    {
        LerpToPage(0);
    }
    public void OnLeaderBoard()
    {
        LerpToPage(1);
    }
    public void OnHome()
    {
        LerpToPage(2);
    }
    public void OnFriends()
    {
        LerpToPage(3);
    }
    public void OnSettings()
    {
        LerpToPage(4);
    }

}
