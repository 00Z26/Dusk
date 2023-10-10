using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{
    private bool isFade;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration; //��ڻ��͸����ʱ��


    private void Awake()
    {
        //��ʼʱ�ȼ���menu����
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }


    public void Transition(string from, string to)
    {

        StartCoroutine(TransitionToScene(from, to));
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        //yield return Fade(1); //�����仯ǰ���ȱ�ڡ�������yield��ʹfadeִ�н�����������ִ�У��������ͬ��ִ��ʹ��StartCoroutine
        if (from != string.Empty)
        {
            yield return SceneManager.UnloadSceneAsync(from);
        }
        //Debug.Log("press");
        //player.SetActive(false);
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); //ִ�к�ֻ�г�פ�ͳ���to

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1); //��ȡ�¼��س��������
        SceneManager.SetActiveScene(newScene);
 

        //yield return Fade(0);//�仯�����󣬽����
    }


    //private IEnumerator Fade(float targetAlpha)
    //{
    //    isFade = true;
    //    fadeCanvasGroup.blocksRaycasts = true;
    //    float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration; //��ֹ�������������ֵ����ʱ��

    //    while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
    //    {
    //        fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
    //        yield return null;
    //    }

    //    fadeCanvasGroup.blocksRaycasts = false;
    //    isFade = false;
    //}

   


   

}
