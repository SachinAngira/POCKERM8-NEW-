using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite TabActive;
    public Sprite Tabideal;
    public Image target;
    public TabButton selectedtab;
    public List<GameObject> swap;
   public bool pp = false;
    public void Subscribe(TabButton buton)
    {
        if (buton == null)
        {
            tabButtons = new List<TabButton>();

        }
        tabButtons.Add(buton);
    }

    public void OnTabEnter(TabButton buton)
    {
        ResetTabs();
        if (selectedtab == null || buton != selectedtab)
        {
            buton.bg.sprite = Tabideal;
        }
    }
    public void OnTabExit(TabButton buton)
    {
        ResetTabs();
    }
    public void OnTabSelected(TabButton buton)
    {
        selectedtab = buton;
        ResetTabs();
        buton.bg.sprite = TabActive;
        if (pp)
        {
        target.sprite = buton.aimage;
        }
        int index = buton.transform.GetSiblingIndex();
        for (int i = 0; i < swap.Count; i++)
        {
            if (i == index)
            {
                swap[i].SetActive(true);
            }
            else
            {
                swap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedtab != null && button == selectedtab)
            { continue; }
            button.bg.sprite = Tabideal;
        }
    }
}
