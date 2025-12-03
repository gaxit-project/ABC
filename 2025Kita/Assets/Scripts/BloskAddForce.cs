using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloskAddForce : MonoBehaviour
{
    public GameObject pushObject;   // このオブジェクトを押すことができるオブジェクト
    Rigidbody rb;
    int force = 50;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (rb == null) return;
        if(other.gameObject == pushObject)
        {
            Vector3 pushDirection = other.transform.forward;
            pushDirection.y = 0;
            pushDirection.Normalize(); 
            rb.AddForce(pushDirection * force, ForceMode.Force);
        }
    }
}
