using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class Registration : UiTransation
{
    public string usernane;
    public Input passWard;
    public Text User;
    public InputField Email;
    public InputField pass;
    public InputField Cpass;
    string path;
    string jsonString; // = "{ \"email\": \"1234@gmail.com\", \"name\": \"123\", \"password\": \"1234\"}"
    string url = "https://pokerm8.xyz/api/auth/user";
    string json;
    public GameObject errorText;
   // public GameObject error;
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

        if (User.text == "" || pass.text == "" || Email.text == "" || Cpass.text =="")
        {
            error.text = "Please fill all the fields";
            Debug.Log("empty");
        }
        if (User.text != "" && pass.text != "")
        {
            error.text = "The username and password you entered do not match any user account. Please check your credentials.";

        }
       


        jsonString = "{ \"email\": \"" + Email.text + "\",\"name\": \"" + User.text + "\", \"password\": \"" + pass.text + "\"}";
        Debug.Log(jsonString);
        if (Cpass.text == pass.text)
        {
            StartCoroutine(Post(url, jsonString));
            PlayerPrefs.SetString("Name", User.text);
        }
        else
        {
            error.text = "Password Fields do not match";
            errorText.SetActive(true);
        }
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
            Email.text = "";
            pass.text = "";
            User.text = "";
            Cpass.text = "";
        }
        if (request.responseCode != 200)
        {
            errorText.SetActive(true);
            User.text = request.responseCode.ToString();

        }
    }
}
