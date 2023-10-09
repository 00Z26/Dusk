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
}
