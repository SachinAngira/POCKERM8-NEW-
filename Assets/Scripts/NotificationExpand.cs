using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationExpand : MonoBehaviour
{
    public RectTransform RT,holder;
    public GameObject Srinkbtn, ExpandBtn;
    public Text TXT;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSrink()
    {
     //   RT.sizeDelta = new Vector2(RT.sizeDelta.x,RT.sizeDelta.y - 178f);
        holder.sizeDelta = new Vector2(RT.sizeDelta.x, 274f);
        ExpandBtn.SetActive(true);
        Srinkbtn.SetActive(false);
         TXT.text  = " Pocker is any number of card games in which players wages over which hand is best according to that specific game's rulesin ways similar to these rankings";

 
    }
    public void OnExpend()
    {
        holder.sizeDelta = new Vector2(RT.sizeDelta.x, 434.3f);
        ExpandBtn.SetActive(false);
        Srinkbtn.SetActive(true);
        TXT.text  = " Pocker is any number of card games in which players wages over which hand is best according to that specific game's rulesin ways similar to these rankings.                                                                                              dsdfsds dfsfs sdfs fh sgsd Sfsdf asdfa dgdsa sdfsadf sadfsad asdfasdf sadfsa sad sadfsadf sfasd fd v dfga asdc asfad asda a asdfas ";
    }
}
