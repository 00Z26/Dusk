using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public TextMeshProUGUI leftDiceNum;
    public TextMeshProUGUI rightDiceNum;
    public TextMeshProUGUI dayDiceNum;
    public TextMeshProUGUI nightDiceNum;

    public GameObject dayDialogue;
    public GameObject nightDialogue;

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

        //��ĵ���
        dayNum = int.Parse(leftNum.ToString() + rightNum.ToString());
        //ҹ�ĵ���
        nightNum = int.Parse(rightNum.ToString() + leftNum.ToString());

        dayDiceNum.text = leftNum.ToString() + rightNum.ToString();
        nightDiceNum.text = rightNum.ToString() + leftNum.ToString();

        calculateManager.CalculateDiceResult(dayNum,nightNum);
        //������������ͬ��Ҫ������һ��
        dayDiceNum.gameObject.transform.parent.gameObject.SetActive(true);
        nightDiceNum.gameObject.transform.parent.gameObject.SetActive(true);
        dayDialogue.GetComponent<Button>().enabled = true;
        nightDialogue.GetComponent<Button>().enabled = true;
        this.gameObject.SetActive(false);
    }


}
