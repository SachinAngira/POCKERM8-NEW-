using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.IO;


public class Log : MonoBehaviour
{
   string url  = "http://ec2-3-17-135-24.us-east-2.compute.amazonaws.com/api/auth/login";
   string json; // = "{ \"password\": \"123456\", \"username\": \"msddirtbags@gmail.com\"}";
   string path;

    void Start()
    {
       path = Application.streamingAssetsPath + "/Login.json";
      json = File.ReadAllText(path);
        

    }

    public void Login()
    {
        StartCoroutine(Post(url, json));
    
    }
    IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.Send();

        Debug.Log("Status Code: " + request.responseCode);
    }
}
