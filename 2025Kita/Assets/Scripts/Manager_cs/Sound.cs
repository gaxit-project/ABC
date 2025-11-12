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
}
