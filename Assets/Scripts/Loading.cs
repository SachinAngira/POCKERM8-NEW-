using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text Percentage;
    void Start()
    {
       
    }

    IEnumerator LoadAsync(int index)
    {
        yield return new WaitForSeconds(3);
        AsyncOperation op = SceneManager.LoadSceneAsync( index);
      
      while(!op.isDone)
      {
          float progress = Mathf.Clamp01(op.progress / .9f);
          //  slider.value = progress;
           // Percentage.text = progress.ToString() + "0";
        
        }
        yield return null;
    }
    public void Play(int index)
    {
        StartCoroutine(LoadAsync(index));
    }
}



