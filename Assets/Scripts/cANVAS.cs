using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cANVAS : MonoBehaviour
{
   public CanvasScaler Canvas;
   public int h, w;
    void Start()
    {
        CanvasScaler.ReferenceEquals(Screen.height,Screen.width);
        Resolution.ReferenceEquals(Screen.height,Screen.width);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
