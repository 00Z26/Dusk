using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelGame : MonoBehaviour
{
    public void OnExitGame()
    {
#if UNITY_EDITOR//�ڱ༭��ģʽ�˳�
        UnityEditor.EditorApplication.isPlaying = false;
#else//�������˳�
        Application.Quit();
#endif
    }

}
