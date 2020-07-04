using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviour
{
    public Text Nickname;
    public Text nick;
    void Start()
    {
        if (PlayerPrefs.GetString("Nick") == null)
        Nickname.text = PlayerPrefs.GetString("Nick");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetNick()
    {
        PlayerPrefs.SetString("Nick", nick.text);
    }
}
