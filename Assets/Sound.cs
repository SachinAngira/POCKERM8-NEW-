using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sound : MonoBehaviour
{
    public bool soundBool = true;
    public Image Currentsound;
    public Sprite on, off;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (soundBool)
        {
            Currentsound.sprite = on;
        }
        else
        {
            Currentsound.sprite = off;
        }
    }
    public void SoundCall()
    {
        soundBool = !soundBool;
    }
}
