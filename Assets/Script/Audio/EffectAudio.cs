using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAudio : MonoBehaviour
{
    public AudioSource clickDialogueSource;
    public AudioSource clickBtnSource;

    private void OnEnable()
    {
        EventHandler.clickAudioEvent += OnPlayEffectAudio;

    }
    private void OnDisable()
    {
        EventHandler.clickAudioEvent -= OnPlayEffectAudio;
    }

    private void OnPlayEffectAudio(int mode)
    {
        if(mode == 1)
            clickDialogueSource.Play();
        if(mode == 2)
            clickBtnSource.Play();
    }


}
