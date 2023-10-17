using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class DialoguePage : MonoBehaviour
{
    public GameObject dialogueObj;
    public List<TextMeshProUGUI> contentList;
    //public TextMeshProUGUI content_1;
    //public TextMeshProUGUI content_2;
    //public TextMeshProUGUI content_3;
    private DialogueView dialogueView;
    private int contentIndex = 0;
    //private List<string> showDialogueList = new List<string>();
    private void Awake()
    {
        dialogueView = dialogueObj.GetComponent<DialogueView>();
    }

    [YarnCommand("page")]
    public void TurnPage()
    {
        contentIndex = 0;
        //showDialogueList.Clear();
        dialogueView.text = contentList[0];
        foreach(TextMeshProUGUI content in contentList)
        {
            content.text = "";
        }
        contentIndex++;
        //content_2.text = "";
        //content_3.text = "";
    }

    public void InPageClick()
    {
        dialogueView.text = contentList[contentIndex];
        contentIndex++;

    }


    //public void AddDialogueList(string content)
    //{
    //    showDialogueList.Add(content);
    //}

}
