using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Dice : MonoBehaviour
{
    public TextMeshProUGUI leftDiceNum;
    public TextMeshProUGUI rightDiceNum;
    public TextMeshProUGUI dayDiceNum;
    public TextMeshProUGUI nightDiceNum;

    public CalculateManager calculateManager;

    private int dayNum, nightNum;

    public void GetDiceNum()
    {   
        System.Random random = new System.Random();
        int leftNum, rightNum;
        leftNum = random.Next(0, 9);
        rightNum = random.Next(0, 9);

        leftDiceNum.text = leftNum.ToString();
        rightDiceNum.text = rightNum.ToString();

        //昼的点数
        dayNum = int.Parse(leftNum.ToString() + rightNum.ToString());
        //夜的点数
        nightNum = int.Parse(rightNum.ToString() + leftNum.ToString());

        dayDiceNum.text = leftNum.ToString() + rightNum.ToString();
        nightDiceNum.text = rightNum.ToString() + leftNum.ToString();

        //这里计算结束后同样要调用下一句

    }


}
