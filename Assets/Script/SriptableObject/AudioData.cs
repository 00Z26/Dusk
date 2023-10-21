using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AudioData", menuName = "SO_Audio")]
public class AudioData : ScriptableObject
{
    public List<AudioClip> audioClips;
    public List<string> titles;


    public AudioClip GetAudioClips(string titleName)
    {
        int clipIndex = GetTitleIndex(titleName);
        try
        {
            return audioClips[clipIndex];
        }
        catch (Exception e)
        {
            //�޶�Ӧ�������쳣��������������
            Debug.Log(e);
            return null;

        }
    }

    public int GetTitleIndex(string titleName)
    {
        if(!this.titles.Contains(titleName))
        {
            
            return -1;
        }
        return this.titles.IndexOf(titleName);
    }


}
