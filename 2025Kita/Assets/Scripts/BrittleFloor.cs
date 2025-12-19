using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevateFloor : MonoBehaviour
{
    private Transform normalTransform;
    [SerializeField] private Transform lowTransform;
    [SerializeField] private GravityControl gravity;
    [SerializeField] private float moveSpeed = 2f;

    private Vector3 targetPosition;
    void Start()
    {
        normalTransform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(gravity.normalGravity)
        {
            targetPosition = normalTransform.position;
        }
        else if(gravity.lowGravity)
        {
            targetPosition = lowTransform.position;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

    }
}
