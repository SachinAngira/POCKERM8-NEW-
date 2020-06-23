using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPanel : MonoBehaviour
{
    public GameObject Target;
    public bool On;
    public void Next(bool On)
    {
        Target.SetActive(On);
    
    }
}
