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

    public ChoiceListView dayChoiceList;
    public ChoiceListView nightChoiceList;
    public GameObject choiceButton;
    public InGameOperate inGameOperator;

    private void Update()
    {
        GameObject ts = GameObject.FindGameObjectWithTag("Choice");
        if (ts != null)
        {
            choiceButton.gameObject.SetActive(true);
        }
    }


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

    public void clickSubmitChoice()
    {
        Debug.Log(dayChoiceList.selectedId);
        if (dayChoiceList.selectedId != -1 && nightChoiceList.selectedId != -1)
        {

            //记录选项内容
            inGameOperator.AddRecord("DayDialogue", dayChoiceList.selectedOption.Line.Text.Text);
            inGameOperator.AddRecord("NightDialogue", nightChoiceList.selectedOption.Line.Text.Text);

            //点击触发下一句

            dayChoiceList.subimtChoice();
            nightChoiceList.subimtChoice();
            choiceButton.SetActive(false);
        }

    }
}
