using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class ForgetPassword : UiTransation
{
    public Text User;
    public InputField Email;
    public InputField pass;
    public InputField Cpass;
    public InputField Otp;
    public Text otpText;
    string code;
    string jsonString; // ="{ \"cpassword\": \"string\", \"otp\": \"string\", \"password\": \"string\", \"username\": \"string\"}"
    string url = "https://pokerm8.xyz/api/auth/fp";
    string OTPurl = "https://pokerm8.xyz/api/auth/otp/";
    string json;
    public GameObject errorText;
    public GameObject OtpIsRIght,CHECK;
    //public GameObject error;
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
        if (Otp.text == "" || pass.text == "" || Email.text == "" || Cpass.text == "")
        {
            error.text = "Please fill all the fields";
            Debug.Log("empty");
        }
        else if (Email.text != "" && pass.text != "")
        {
            error.text = "The username and password you entered do not match any user account. Please check your credentials.";

        }
       


        jsonString = "{ \"cpassword\": \"" + pass.text + "\", \"otp\": \"" + Otp.text + "\", \"password\": \"" + pass.text + "\", \"username\": \"" + Email.text + "\"}";
        Debug.Log(jsonString);
        if (Cpass.text == pass.text)
        {
            StartCoroutine(Post(url, jsonString));
        }
        else
        {

            error.text = "Password Fields do not match";
            errorText.SetActive(true);
        }
    }

    public void SendOtp()
    {

        OTPurl = OTPurl + Email.text;
      
     //  otpText.text = "Check";
     //  CHECK.SetActive(true);
       if (Email.text == "")
       {
           error.text = "Please fill Email fields with an proper email";
           Debug.Log("empty");
           errorText.SetActive(true);
       }
       else {
           StartCoroutine(GetRequest(OTPurl));
           error.text = "We just send OTP email, please find it!";
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
           error.text = "Something Went Wrong";

        }

    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.responseCode != 200)
            {
                error.text = "Email not found";
                Debug.Log("empty");
                errorText.SetActive(true);
            }
            if (webRequest.isNetworkError)
            {
                error.text = "Email not found";
                Debug.Log("empty");
                errorText.SetActive(true);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
               code = webRequest.downloadHandler.text;

            }
        }
    }
    public void OtoCeheck()
    {
        Debug.Log(code);
        if(Otp.text == code)
        {
            OtpIsRIght.SetActive(true);
            error.text = "The verification password you entered is correct. You can now define new password.";
        }
    
    
    }
}
