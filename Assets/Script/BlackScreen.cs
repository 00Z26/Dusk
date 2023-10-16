using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������һ��ȫ��ͼƬ������Ļ������͸����ʹ��curve��
public class BlackScreen : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;//������Ļ��һ��ȫ��ͼƬ
    public AnimationCurve curve; //��Inspector�ϵ����Լ�ϲ��������
    public AnimationCurve blackCurve; //��Inspector�ϵ����Լ�ϲ��������

    [Range(0.5f, 2f)] public float speed = 1f; //���ƽ��뽥�����ٶ�

    private void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //�����Զ����ź���
    private void OnEnable()
    {
        StartCoroutine(Black());
    }

    Color tmpColor; //���ڴ�����ɫ�ı���
    public IEnumerator Black()
    {
        float timer = 0f;
        tmpColor = spriteRenderer.color;
        do
        {
            timer += Time.deltaTime;
            SetColorAlpha(curve.Evaluate(timer * speed));
            yield return null;

        } while (tmpColor.a > 0);
        gameObject.SetActive(false);
    }

    //ͨ������ͼƬ��͸����ʵ�ֽ��뽥��
    void SetColorAlpha(float a)
    {
        tmpColor.a = a;
        spriteRenderer.color = tmpColor;
    }
}