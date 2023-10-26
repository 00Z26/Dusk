using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueAudio : MonoBehaviour
{
    public AudioData dialogueAudio;
    public AudioSource audioSource;
    private string titleName;


    //”……Ë÷√±≥æ∞Õº∆¨µƒ√¸¡Ó¥•∑¢
    public void SetDialogueAudio(string name) 
    { 
        titleName = name;
        AudioClip dialogueClip = dialogueAudio.GetAudioClips(titleName);
        if (dialogueClip != null)
        {
            audioSource.clip = dialogueClip;
            audioSource.Play();
        }

        
    }

    [YarnCommand("pause")]
    public void PauseDialogueAudio()
    {
        audioSource.Pause();
    }

    [YarnCommand("continue")]
    public void ContimueAudio()
    {
        audioSource.Play();
    }


}
