using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    public GameObject pushObject;   // このオブジェクトを押すことができるオブジェクト
    Rigidbody rb;
    int force = 50;
    private float waitseconds = 5f;
    public bool isFalled = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (rb == null) return;
        if (collision.gameObject == pushObject)
        {
            Vector3 pushDirection = transform.position - collision.transform.position;
            pushDirection.y = 0;
            pushDirection.Normalize();
            rb.AddForce(pushDirection * force, ForceMode.Force);

            StartCoroutine(WaitSeconds());
        }
    }

    private IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(waitseconds);
        isFalled = true;
    }
}
