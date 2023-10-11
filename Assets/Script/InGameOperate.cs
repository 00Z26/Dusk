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
            nightLog.text = nightLog.text + content + "\n";
        }
    }

    public string ShowMultiDialogue(string name)
    {
        string dialogueText = "\n";

        if (dayContent.Count >= 2 || nightContent.Count >2)
        {
            List<string> list = new List<string>();
            if (name == "DayDialogue")

                list = dayContent.GetRange(dayContent.Count - 2, 2);

            else if (name == "NightDialogue")

                list = nightContent.GetRange(dayContent.Count - 2, 2);
          
            foreach (string content in list)
            {
                dialogueText = dialogueText + content + "\n\n";
            }

        } 
        else if(dayContent.Count == 1 || nightContent.Count == 1)
        {
            if (name == "DayDialogue")
            {

                dialogueText = dayContent[0]+"\n";

            }
            else if (name == "NightDialogue")
            {
                dialogueText = nightContent[0]+"\n";

            }
        }
        return dialogueText;
    }
}
