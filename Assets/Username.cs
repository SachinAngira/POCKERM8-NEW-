using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Username : MonoBehaviour
{
    public Text username;
    void Start()
    {
        username.text = PlayerPrefs.GetString("Name");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
