using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Conection : MonoBehaviour
{
  public  string Username;
    public string Password;
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
        form.AddField("password", Password);
       form.AddField("username", Username);

       using (UnityWebRequest www = UnityWebRequest.Post("http://ec2-3-17-135-24.us-east-2.compute.amazonaws.com/api/auth/login", "{ \"password\": \"123456\", \"username\": \"msddirtbags@gmail.com\"}"))
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

