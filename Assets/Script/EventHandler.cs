using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler 
{
    public static event Action<int> clickAudioEvent;  



    public static void CallClickAudio(int clickMode)
    {
        clickAudioEvent?.Invoke(clickMode);
    }


}