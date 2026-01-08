using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrittleFloor : MonoBehaviour
{
    [SerializeField] private PlayerStatus PS;
    //[SerializeField] private float brokenHeight = 3.0f;
    [SerializeField] private GameObject breaker;
    [SerializeField] private ParticleSystem breakerParticle;
    [SerializeField] Sound sound;


    public void OnCollisionEnter(Collision collision)
    {
        if (breaker != null && breakerParticle != null)
        {
            if (collision.gameObject == breaker)
            {
                if(PS.hardLanding)
                {
                    this.gameObject.SetActive(false);
                    breakerParticle.Play();
                    sound.PlayBreak();
                }
            }
        }
    }
}