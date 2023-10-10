using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameOperate : MonoBehaviour
{
    public TextMeshProUGUI dayLog;
    public TextMeshProUGUI nightLog;

    public List<string> dayContent;
    public List<string> nightContent;
    public void AddRecord(string name,string text)
    {
        if(name == "DayDialogue")
        {
            dayContent.Add(text);
        }else if(name == "NightDialogue")
        {
            nightContent.Add(text);
        }
        Debug.Log(dayContent);
    }

    public void ShowDayHistory()
    {
        foreach(string content in dayContent)
        {
            dayLog.text = dayLog.text + content + "\n";
        }
    }
    public void ShownightHistory()
    {
        foreach (string content in dayContent)
        {
            nightLog.text = nightLog.text + content;
        }
    }

    public string ShowMultiDialogue(int num)
    {
        string dialogueText = "";

        if(dayContent.Count >= 3)
        {
            //List<string> list = new List<string>();
            List<string> list = dayContent.GetRange(dayContent.Count - 2, 2);
            //list.Add(dayContent[^1]);
            //list.Add(dayContent[^2]);

            foreach (string content in list)
            {
                dialogueText = dialogueText + content + "\n\n\n";
            }
        } else if(dayContent.Count == 2)
        {
            dialogueText = dayContent[1];
        }
        return dialogueText;
    }
}
