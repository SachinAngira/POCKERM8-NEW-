using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyField : MonoBehaviour
{
    public InputField a;
    public InputField b;
    public InputField c;
    public InputField d;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Empty()
    {
        a.text = "";
        b.text = "";
            c.text = "";
            d.text = "";
      
    }
}
