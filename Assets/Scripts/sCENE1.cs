using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sCENE1 : MonoBehaviour
{
    public Slider slider;
    public float ToMultiply;
    public Text text;
    int i;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

         i = (int)(slider.value * ToMultiply);

        //   ToMultiply *= slider.value;
        text.text = i.ToString();
    }
    void FixedUpdate()
    {
       
        if (i == 100)
        {
             SceneManager.LoadScene(1);
        }
        slider.value += .01f;
    }
 //   IEnumerator Load()
    

       
           
         
       // yield return new WaitForSeconds(2f);

    }

