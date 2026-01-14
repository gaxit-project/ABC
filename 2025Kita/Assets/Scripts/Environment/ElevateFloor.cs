using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevateFloor : MonoBehaviour
{
    [SerializeField] private Transform normalTransform;
    [SerializeField] private Transform lowTransform;
    [SerializeField] private GravityControl gravity;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Sound sound;

    private Vector3 targetPosition;
    private bool isMoving;
    private bool wasMoving;
    void Start()
    {
        targetPosition = normalTransform.position;
        transform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (gravity.normalGravity)
        {
            targetPosition = normalTransform.position;
        }
        else if (gravity.lowGravity)
        {
            targetPosition = lowTransform.position;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        wasMoving = isMoving;

        isMoving = Vector3.Distance(transform.position, targetPosition) > 0.001f;

        if (!wasMoving && isMoving)
        {
            sound.PlayMove();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

}

