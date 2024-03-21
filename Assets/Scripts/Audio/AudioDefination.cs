using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDefination : MonoBehaviour
{
    public PlayAudioEventSO playAudioEvent;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    public bool playOnEable;
    private void OnEnable()
    {    
        if (playOnEable)
             PlayAudioClip();
        
    }
    public void PlayAudioClip()
    {

        playAudioEvent.OnEventRaised(audioClip);

    }
    public void PlayAudioClip2()
    {

        playAudioEvent.OnEventRaised(audioClip2);

    }

}

