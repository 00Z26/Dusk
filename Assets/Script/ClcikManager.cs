using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ClcikManager : MonoBehaviour
{
    public GameObject wishBtn;
    public GameObject dayDialogue;
    public GameObject nightDialogue;

    //������Ҫ���������Ժ��޸ĵı���
    private string dayDiceAttr;
    private string dayVariableName;
    private string nightDiceAttr;
    private string nightVariableName;

    [YarnCommand("wish")]
    public void ClickWish()
    {
        wishBtn.SetActive(true);
        dayDialogue.GetComponent<Button>().enabled = false;
        nightDialogue.GetComponent<Button>().enabled = false;
    }
    [YarnCommand("a_roll")]
    public void GetDayDiceAttribute(string attr, string variable)
    {
        dayDiceAttr = attr;
        dayVariableName = variable;
    }

    [YarnCommand("b_roll")]
    public void GetNightDiceAttribute(string attr, string variable)
    {
        nightDiceAttr = attr;
        nightVariableName = variable;
    }
}
