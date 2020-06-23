using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System.Text;

public class LogIn : UiTransation
{
    public string usernane; 
    public Input passWard; 
    public Text User;
    public InputField pass;
    string path;
    string jsonString; // = "{ \"password\": \"123456\", \"username\": \"msddirtbags@gmail.com\"}";
    string url = "http://ec2-3-17-135-24.us-east-2.compute.amazonaws.com/api/auth/login";
    string json;
    public GameObject errorText;
    public Text error;
    void Start()
    {
     
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnSubmit()
    {
        logdata user = new logdata();
       //user.username = User.text;
      //  user.passward = pass.text;
    // jsonString = JsonUtility.ToJson(user);

      CurrntUI.SetActive(false);
       TargetUI.SetActive(true);
        Debug.Log(usernane);
        Debug.Log(passWard);
      jsonString = "{ \"password\": \"" + pass.text + "\", \"username\": \"" + User.text + "\"}";
        Debug.Log(jsonString);
        StartCoroutine(Post(url, jsonString));
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
        error.text = request.responseCode.ToString();
        if (request.responseCode == 200)
        {
            CurrntUI.SetActive(false);
             TargetUI.SetActive(true);
        }
        if (request.responseCode != 200)
        {
        errorText.SetActive(true);
        User.text = request.responseCode.ToString();
      
        }

    }
}
[System.Serializable]
public class logdata
{
    public string passward;
    public string username;
}