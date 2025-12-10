using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StopPressMachine2 : MonoBehaviour
{
    public bool isStop = false;
    private bool wasStop = false;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isStop && !wasStop)
        {
            StartCoroutine(DisableAnimatorAfterTransition(0.01f));
            wasStop = true;
        }
        else if (!isStop && wasStop)
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
            rb.isKinematic = true;
            wasStop = false;
        }
    }

    IEnumerator DisableAnimatorAfterTransition(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.isKinematic = false;
    }
}