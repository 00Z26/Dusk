using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ChangeImage : MonoBehaviour
{
    public GameObject dayScreen;
    public GameObject nightScreen;
    public GameObject dayBubble;
    public GameObject nightBubble;

    private string screenPath = "dialogue/";
    private string bubblePath = "dialogue/";

    [YarnCommand("background")]
    public void ChangeTitleImage(string imageName)
    {
        Sprite tmp = Resources.Load(screenPath + imageName.Substring(1)) as Sprite;
        if (imageName.Substring(0, 2) == "$a")
        {
            dayScreen.GetComponent<Image>().sprite = tmp ;
        }else if (imageName.Substring(0, 2) == "$b")
        {
            nightScreen.GetComponent<Image>().sprite = tmp;

        }
        Debug.Log("无对应变量");
    }

    [YarnCommand("bubble")]
    public void ChangeBubbleImage(string bubbleName)
    {
        Sprite tmp = Resources.Load(screenPath + bubbleName.Substring(1)) as Sprite;
        if (bubbleName.Substring(0, 2) == "$a")
        {
            dayBubble.GetComponent<Image>().sprite = tmp;
        }
        else if (bubbleName.Substring(0, 2) == "$b")
        {
            nightBubble.GetComponent<Image>().sprite = tmp;

        }
        Debug.Log("无对应气泡");
    }


}
