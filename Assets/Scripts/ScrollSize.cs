using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSize : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(target.transform.position.x - transform.position.x) < 5)
        {
            transform.localScale = new Vector3(.7f, .7f, .7f);
        }
        else
        {

            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
