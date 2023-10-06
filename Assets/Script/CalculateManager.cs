using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateManager : MonoBehaviour
{

    //投掷鉴定结果
    public bool CalculateDiceResult(AttributeData attributeData, int diceNum)
    {   
        //待处理：属性判断
        if(attributeData.attribute[0] > diceNum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //public int VariableToAttrIndex(string variableName)
    //{
    //    return 0;
    //}
}
