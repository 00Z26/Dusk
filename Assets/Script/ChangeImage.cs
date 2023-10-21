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

    public AnimationCurve whiteCurve;
    public AnimationCurve blackCurve;
    public DialogueAudio dialogueAudio;

    [Range(0.5f, 2f)] public float speed = 1f;
    private SpriteRenderer dayblackCanvas;
    private SpriteRenderer nightblackCanvas;

    Color dayColor;

    private string screenPath = "img/title/";
    private string bubblePath = "dialogue/";
    private string endPicPath = "img/end/";


    private void OnEnable()
    {
        dayblackCanvas = dayScreen.GetComponent<SpriteRenderer>();
        nightblackCanvas = nightScreen.GetComponent<SpriteRenderer>();

        dayColor = dayblackCanvas.color;
        
    }



    [YarnCommand("background")]
    public void ChangeTitleImage(string imageName)
    {
        StartCoroutine(Change(imageName));

        //把图片节点的名称传给音乐设置
        dialogueAudio.SetDialogueAudio(imageName.Substring(1));
        //string path = screenPath + imageName.Substring(1);
        //Color tmpDayColor = dayblackCanvas.color;

        //Texture2D tmp2D = Resources.Load(path) as Texture2D;
        //Sprite tmp = Sprite.Create(tmp2D, new Rect(0, 0, tmp2D.width, tmp2D.height), new Vector2(0.5f, 0.5f));
        //if (imageName.Substring(0, 2) == "$a")
        //{
        //    //dayScreen.transform.GetChild(0)?.gameObject.SetActive(true);
        //    dayScreen.GetComponent<SpriteRenderer>().sprite = tmp;
        //}
        //else if (imageName.Substring(0, 2) == "$b")
        //{
        //    nightScreen.GetComponent<SpriteRenderer>().sprite = tmp;

        //}

        Debug.Log("无对应变量");
    }

    Color tmpDayColor; //用于传递颜色的变量
    Color tmpNightColor; //用于传递颜色的变量

    public IEnumerator Black(AnimationCurve curveMode)
    {
        float timer = 0f;
        tmpDayColor = dayblackCanvas.color;
        tmpNightColor = dayblackCanvas.color;

        do
        {
            timer += Time.deltaTime;
            SetColorAlpha(curveMode.Evaluate(timer * speed));
            yield return new WaitForFixedUpdate();


        } while (tmpDayColor.a > 0.5);
        //gameObject.SetActive(false);

    }

    public IEnumerator White(AnimationCurve curveMode)
    {
        float timer = 0f;
        tmpDayColor = dayblackCanvas.color;
        tmpNightColor = dayblackCanvas.color;
        do
        {
            timer += Time.deltaTime;
            SetColorAlpha(curveMode.Evaluate(timer * speed) );
            yield return new WaitForFixedUpdate();

        } while (tmpDayColor.a < 1 && tmpDayColor.a > 0);
        //gameObject.SetActive(false);

    }

    //通过调整图片的透明度实现渐入渐出
    void SetColorAlpha(float a)
    {
        tmpDayColor.a = a;
        tmpNightColor.a = a;

        dayblackCanvas.color = tmpDayColor;
        nightblackCanvas.color = tmpNightColor;

    }

    public IEnumerator Change(string imageName)
    {
        string path = screenPath + imageName.Substring(1);
        yield return StartCoroutine(Black(whiteCurve));

        Texture2D tmp2D = Resources.Load(path) as Texture2D;
        Sprite tmp = Sprite.Create(tmp2D, new Rect(0, 0, tmp2D.width, tmp2D.height), new Vector2(0.5f, 0.5f));
        if (imageName.Substring(0, 2) == "$a")
        {
            dayScreen.GetComponent<SpriteRenderer>().sprite = tmp;
            //dayColor.a = 255;
            //dayScreen.GetComponent<SpriteRenderer>().color = dayColor;
        }
        else if (imageName.Substring(0, 2) == "$b")
        {
            nightScreen.GetComponent<SpriteRenderer>().sprite = tmp;

        }
        StartCoroutine(White(blackCurve));
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
