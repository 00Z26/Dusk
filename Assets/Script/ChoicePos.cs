using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePos : MonoBehaviour
{
    public DialoguePage dialoguePage;
    private Vector3 topChoicePos = new Vector3(-317, 21, 0);
    
    public void SetChoicePos()
    {
        float choiceYPos = topChoicePos.y - (dialoguePage.GetIndex()-2) * 70;
        Vector3 intialPos = this.gameObject.GetComponent<RectTransform>().anchoredPosition3D;
        Vector3 newPos = new Vector3(intialPos.x,choiceYPos,intialPos.z);
        this.gameObject.GetComponent<RectTransform>().anchoredPosition3D = newPos;
    }
}
