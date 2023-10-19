using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudio : MonoBehaviour
{
    private string titleName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //节点名称由设置背景图片的命令调用赋值
    public void SetTitleName(string name) { titleName = name; }


}
