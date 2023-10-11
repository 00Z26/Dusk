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
    public Image endShow;

    private string screenPath = "img/title/";
    private string bubblePath = "dialogue/";
    private string endPicPath = "img/end/";

    [YarnCommand("background")]
    public void ChangeTitleImage(string imageName)
    {
        string path = screenPath + imageName.Substring(1);

        Texture2D tmp2D = Resources.Load(path) as Texture2D;
        Sprite tmp = Sprite.Create(tmp2D, new Rect(0, 0, tmp2D.width, tmp2D.height), new Vector2(0.5f, 0.5f));

        if (imageName.Substring(0 , 2) == "$a")
        {
            dayScreen.GetComponent<SpriteRenderer>().sprite = tmp ;
        }else if (imageName.Substring(0 , 2) == "$b")
        {
            nightScreen.GetComponent<SpriteRenderer>().sprite = tmp;

        }
        Debug.Log("无对应变量");
    }

    [YarnCommand("bubble")]
    public void ChangeBubbleImage(string bubbleName)
    {
        string path = bubblePath + bubbleName.Substring(1);

        Texture2D tmp2D = Resources.Load(path) as Texture2D;
        Sprite tmp = Sprite.Create(tmp2D, new Rect(0, 0, tmp2D.width, tmp2D.height), new Vector2(0.5f, 0.5f));

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

    [YarnCommand("end")]
    public void ShowEndPic(string picName)
    {
        string path = endPicPath + picName.Substring(1);

        Texture2D tmp2D = Resources.Load(path) as Texture2D;
        Sprite tmp = Sprite.Create(tmp2D, new Rect(0, 0, tmp2D.width, tmp2D.height), new Vector2(0.5f, 0.5f));

        endShow.sprite = tmp;
    }


}
