using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public string[] data;
    public Text[] DataToGet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnGetData()
    {
     int loopToGo;
        if (data.Length > DataToGet.Length)
        {
             loopToGo = data.Length;
        }
        else
             loopToGo = DataToGet.Length;
        for (int i = 0; i < loopToGo; i++)
        {
            data[0] = DataToGet[0].text;
        }
    }
}
