using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDrag : MonoBehaviour
{
    private Vector3 mOffSet;
    private float zMCoords;
    void OnMouseDown()
    {
        zMCoords = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffSet = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
       
        Vector3 MousePoint = Input.mousePosition;
        MousePoint.z = zMCoords;
        return Camera.main.ScreenToWorldPoint(MousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffSet;
    }
    void Update()
    {
        gameObject.GetComponent<HingeJoint>().connectedAnchor.Set(0f,5f,0f);
    }
}
