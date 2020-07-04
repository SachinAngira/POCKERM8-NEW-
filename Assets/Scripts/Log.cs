using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.IO;


public class Log : UiTransation
{
    void Start()
    {
        if (PlayerPrefs.GetString("Login") == "Login")
        {
            CurrntUI.SetActive(false);
            TargetUI.SetActive(true);
        }
    }
}
