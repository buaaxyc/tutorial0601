using CrazyMinnow.SALSA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    private bool playState = false;
    //public CrazyMinnow.SALSA.Salsa salsaInstance;          // reference to SALSA
    CrazyMinnow.SALSA.Salsa salsaInstance;
    public AudioClip audioClip;

    public Image m_Image;
    //Set this in the Inspector
    public Sprite playBtn;
    public Sprite pauseBtn;

    private void Start()
    {
        salsaInstance = GetComponent<Salsa>();
    }

    public void AudioPlay()
    {
        playState = !playState;
        // controlling the AudioSource/Clip via SALSA's reference to the AudioSource.
        salsaInstance.audioSrc.clip = audioClip;    // load your AudioClip
        if (playState)
        {
            m_Image.sprite = pauseBtn;
            salsaInstance.audioSrc.Play();                  // play the clip
        }
        else
        {
            m_Image.sprite = playBtn;
            salsaInstance.audioSrc.Pause();                 // pause the clip
        }
        //salsaInstance.audioSrc.Stop();                  // stop the clip
        //Debug.Log("Audio Play...");
    }
}
