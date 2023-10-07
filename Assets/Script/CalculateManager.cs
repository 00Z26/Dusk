using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateManager : MonoBehaviour
{
    public AttributeData dayAttrList;
    public AttributeData nightAttrList;
    public ClickManager clickManager;
    public BranchData branchData;

    //投掷鉴定结果
    public void CalculateDiceResult(int dayDiceNum, int nightDiceNum)
    {
        string attribute = clickManager.dayDiceAttr;
        int dayResult = -1;
        int nightResult = -1;
        //待处理：属性判断
        if(dayAttrList.attribute[dayAttrList.GetAttrIndex(attribute.Substring(3, attribute.Length - 3))] > dayDiceNum)
        {
            dayResult = 1;
        }
        else
        {
            dayResult = 0;
        }
        if (nightAttrList.attribute[nightAttrList.GetAttrIndex(attribute.Substring(3, attribute.Length - 3))] > nightDiceNum)
        {
            nightResult = 1;
        }
        else
        {
            nightResult = 0;
        }
        branchData.SetValue(clickManager.dayVariableName.Replace("$",""), dayResult);
        branchData.SetValue(clickManager.nightVariableName.Replace("$", ""), nightResult);

    }


    //public int VariableToAttrIndex(string variableName)
    //{
    //    return 0;
    //}
}
