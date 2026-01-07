using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBridge : MonoBehaviour
{
    [SerializeField] private GameObject breaker;
    [SerializeField] private ParticleSystem breakerParticle;
    [SerializeField] private FallDown FD;
    [SerializeField] Sound sound;



    public void OnCollisionStay(Collision collision)
    {
        if (!FD.isFalled) return;
        if(breaker != null && breakerParticle != null)
        {
            if(collision.gameObject == breaker)
            {

                this.gameObject.SetActive(false);
                breakerParticle.Play();
                sound.PlayBreak();
            }
        }
    }

    //public IEnumerator 
}
