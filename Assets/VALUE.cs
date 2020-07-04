using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VALUE : MonoBehaviour
{
    public Slider slider;
    public float ToMultiply;
    public Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = (int)(slider.value * ToMultiply);
            
     //   ToMultiply *= slider.value;
        text.text = i.ToString();
    }
}
