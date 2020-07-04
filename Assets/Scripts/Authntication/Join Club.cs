using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System.Text;

public class JoinClub : UiTransation
{
     public string usernane; 
    public Input passWard; 
    public Text User;
    public InputField pass;
    string path;
    string jsonString; // = "{ \"email\": \"123@gmail.com\", \"password\": \"1234\"}";
    string url = "https://pokerm8.xyz/api/auth/club/sds/join";
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
        if (User.text == "")
        {
            error.text = "Please! Enter username";
            Debug.Log("empty");
        }
          if (pass.text == "")
        {
            error.text = "Please! Enter password";
            Debug.Log("empty");
        }
        if (User.text == "" && pass.text == "")
        {
            error.text = "Please! Enter username and password";
            Debug.Log("empty");
        }
        if (User.text != "" && pass.text != "")
        {
            error.text = "The username and password you entered do not match any user account. Please check your credentials.";
           
        }
        jsonString = "{ \"agent\": \"" + User.text + "\", \"club\": \"" + pass.text + "\"}";
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
       // error.text = request.responseCode.ToString();
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

