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

    private RectTransform daySize;
    private RectTransform nightSize;

    private void Start()
    {
        daySize = dayLog.gameObject.GetComponent<RectTransform>();
        nightSize = nightLog.gameObject.GetComponent<RectTransform>();
    }
    public void AddRecord(string name,string text)
    {
        if(name == "DayDialogue")
        {
            dayContent.Add(text);
        }else if(name == "NightDialogue")
        {
            nightContent.Add(text);
        }
        daySize.sizeDelta = new Vector2(0, daySize.sizeDelta.y + 40);
        nightSize.sizeDelta = new Vector2(0, nightSize.sizeDelta.y + 40);
    }

    public void ShowDayHistory()
    {
        foreach(string content in dayContent)
        {
            dayLog.text = dayLog.text + content + "\n\n";
        }
    }
    public void ShownightHistory()
    {
        foreach (string content in dayContent)
        {
            nightLog.text = nightLog.text + content + "\n\n";
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
