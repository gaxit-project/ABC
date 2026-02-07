using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StopPressMachine2 : MonoBehaviour
{
    public bool isStop = false;
    private bool wasStop = false;

    [SerializeField] private MovingPlatform platform;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isStop && !wasStop)
        {
            if (platform != null)
            {
                rb.MovePosition(new Vector3(
                rb.position.x,
                platform.topY,
                rb.position.z
                ));
                platform.enabled = false;
            }
            wasStop = true;
        }
        else if (!isStop && wasStop)
        {
            if (platform != null)
            {
                platform.enabled = true; 
            }
            wasStop = false;
        }
    }

    IEnumerator DisableAnimatorAfterTransition(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.isKinematic = false;
    }

    public bool RtnisStop()
    {
        return isStop;
    }
    public bool RtnwasStop()
    {
        return wasStop;
    }

}