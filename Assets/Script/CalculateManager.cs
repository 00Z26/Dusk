using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateManager : MonoBehaviour
{

    //Ͷ���������
    public bool CalculateDiceResult(AttributeData attributeData, int diceNum)
    {   
        //�����������ж�
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
