using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class DialoguePage : MonoBehaviour
{
    public GameObject dialogueObj;
    public List<TextMeshProUGUI> contentList;

    private DialogueView dialogueView;
    private int contentIndex = 0;


    private void Awake()
    {
        dialogueView = dialogueObj.GetComponent<DialogueView>();
    }

    [YarnCommand("page")]
    public void TurnPage(int sentenceNum = 0)
    {
        //对传值进行校验
        //if (sentenceNum > 9)
        //    sentenceNum = 9;

        contentIndex = 0;
        //showDialogueList.Clear();
        dialogueView.text = contentList[0];
        foreach(TextMeshProUGUI content in contentList)
        {
            content.text = "";
        }
        contentIndex++;

        //传值时，激活对应的文本框数
        //for(int i = 0; i < sentenceNum; i++)
        //{
        //    contentList[i].gameObject.SetActive(true);
        //}

    }

    public void InPageClick()
    {
        dialogueView.text = contentList[contentIndex];
        contentIndex++;

    }

    public void InChoiceClick(string selectedChoice)
    {
        contentIndex--;
        contentList[contentIndex].text = selectedChoice;
        contentIndex++;
        dialogueView.text = contentList[contentIndex];
        contentIndex++;

    }

    private void OnPlayEffectAudio()
    {
        int mode = 1;
        EventHandler.CallClickAudio(mode);
    }

    public void ChangeIndex()
    {
        contentIndex--;
    }

    public int GetIndex()
    {
        return contentIndex;
    }
}
