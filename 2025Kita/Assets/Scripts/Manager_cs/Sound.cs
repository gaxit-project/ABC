using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip audioClip;

    public void PlayStamp()
    {
        audiosource.PlayOneShot(audioClip);
    }

    public void PlayBreak()
    {
        audiosource.PlayOneShot(audioClip);
    }

    public void PlayButton()
    {
        audiosource.PlayOneShot(audioClip);
    }

    public void PlayMove()
    {
        audiosource.PlayOneShot(audioClip);
    }
}
