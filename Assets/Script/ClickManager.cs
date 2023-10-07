using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ClickManager : MonoBehaviour
{
    public GameObject wishBtn;
    public GameObject dayDialogue;
    public GameObject nightDialogue;

    public GameObject dice;
    public GameObject dayDiceShow;
    public GameObject nightDiceShow;

    //接下来要鉴定的属性和修改的变量
    public string dayDiceAttr;
    public string dayVariableName;
    public string nightDiceAttr;
    public string nightVariableName;

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
        dice.SetActive(true);
        dayDiceAttr = attr;
        dayVariableName = variable;
        dayDialogue.GetComponent<Button>().enabled = false;
        nightDialogue.GetComponent<Button>().enabled = false;
        Debug.Log(dayDiceAttr);
    }

    [YarnCommand("b_roll")]
    public void GetNightDiceAttribute(string attr, string variable)
    {
        dice.SetActive(true);
        nightDiceAttr = attr;
        nightVariableName = variable;
        dayDialogue.GetComponent<Button>().enabled = false;
        nightDialogue.GetComponent<Button>().enabled = false;
    }
}
