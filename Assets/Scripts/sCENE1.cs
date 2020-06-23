using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sCENE1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load());
       
    }

    IEnumerator Load()
    {
       
       
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
