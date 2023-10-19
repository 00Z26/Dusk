using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelGame : MonoBehaviour
{
    public void OnExitGame()
    {
#if UNITY_EDITOR//在编辑器模式退出
        UnityEditor.EditorApplication.isPlaying = false;
#else//发布后退出
        Application.Quit();
#endif
    }

}
