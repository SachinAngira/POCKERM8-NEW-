using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Conection : MonoBehaviour
{
  public  string Username;
    public string Password;
    public string URL;
    void Start()
    {
        
    }
    public void Login()
    {
        StartCoroutine(Upload(Username, Password));
    
    }
    IEnumerator Upload(string Username, string Password)
    {
        
        WWWForm form = new WWWForm();
        form.AddField("username", Username);
        form.AddField("password", Password);
       

       using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);

                      Debug.Log(www.error);
                
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }

    }
}

