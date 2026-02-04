using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float explosionForce = 5f;
    public float upForce = 1.0f;

    private void OnEnable()
    {
        Explode();
    }

    public void Explode()
    {
        Rigidbody[] shell = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in shell)
        {
            Vector3 direction = (rb.transform.position - transform.position).normalized;
            direction += new Vector3(Random.Range(-0.2f, 0.2f), upForce, Random.Range(-0.2f, 0.2f)); ;
            rb.AddForce(direction * explosionForce, ForceMode.Impulse);
            rb.AddTorque(Random.insideUnitSphere * 10f, ForceMode.Impulse);
        }
    }
}
