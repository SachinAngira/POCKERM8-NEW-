using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTransation : MonoBehaviour
{
    public GameObject TargetUI,CurrntUI;


    public void Translate()
    {
        TargetUI.SetActive(true);
        CurrntUI.SetActive(false);
    }
}
