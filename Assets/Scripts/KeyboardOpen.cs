using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardOpen : MonoBehaviour
{
    public void keyboard()
    {
        TouchScreenKeyboard.Open("text");
        TouchScreenKeyboard.hideInput = true;
    }
    public void OnMouseDown()
    {
        keyboard();
    }
}
