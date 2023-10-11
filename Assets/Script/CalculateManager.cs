using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculateManager : MonoBehaviour
{
    public AttributeData dayAttrList;
    public AttributeData nightAttrList;
    public ClickManager clickManager;
    public BranchData branchData;

    //投掷鉴定结果
    public void CalculateDiceResult(int dayDiceNum, int nightDiceNum, TextMeshProUGUI dayDiceText, TextMeshProUGUI nightDiceText)
    {
        string attribute = clickManager.dayDiceAttr;
        int dayResult = -1;
        int nightResult = -1;
        //待处理：属性判断
        if(dayAttrList.attribute[dayAttrList.GetAttrIndex(attribute.Substring(3, attribute.Length - 3))] >= dayDiceNum)
        {
            dayResult = 1;
            dayDiceText.color = Color.green;
        }
        else
        {
            dayResult = 0;
            dayDiceText.color = Color.red;
        }
        if (nightAttrList.attribute[nightAttrList.GetAttrIndex(attribute.Substring(3, attribute.Length - 3))] >= nightDiceNum)
        {
            nightResult = 1;
            nightDiceText.color = Color.green;
        }
        else
        {
            nightResult = 0;
            nightDiceText.color = Color.red;

        }
        branchData.SetValue(clickManager.dayVariableName.Replace("$",""), dayResult);
        branchData.SetValue(clickManager.nightVariableName.Replace("$", ""), nightResult);

    }


    //public int VariableToAttrIndex(string variableName)
    //{
    //    return 0;
    //}
}
