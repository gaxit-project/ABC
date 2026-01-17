using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject killEgg;
    [SerializeField] Sound sound;

    public float topY = 2f;
    public float bottomY = -2f;

    public float fallSpeed = 12f;  // 落下最大速度
    public float riseSpeed = 4f;   // 上昇最大速度

    public float fallAccel = 30f;  // 落下加速度
    public float riseAccel = 10f;  // 上昇加速度

    private float currentSpeed = 0f;
    private bool goingDown = true;
    private bool pressing = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.isKinematic = false;  // Kinematic でなくても MovePosition は可
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        sound = GetComponent<Sound>();
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        float targetSpeed = goingDown ? -fallSpeed : riseSpeed;
        float accel = goingDown ? fallAccel : riseAccel;

        // 速度を加速・減速
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, accel * Time.fixedDeltaTime);

        // 次の位置
        Vector3 next = rb.position + Vector3.up * currentSpeed * Time.fixedDeltaTime;

        // MovePosition で確実に動かす（重みの影響を受けない）
        rb.MovePosition(next);

        // 到達判定
        if (goingDown && rb.position.y <= bottomY)
        {
            goingDown = false;
            currentSpeed = 0;
            sound.PlayStamp();
            StartCoroutine(Press());
        }
        else if (!goingDown && rb.position.y >= topY)
        {
            goingDown = true;
            pressing = true;
            currentSpeed = 0;
        }

        if (pressing)
        {
            killEgg.SetActive(true);
        }
        else if (!pressing)
        {
            killEgg.SetActive(false);
        }
    }

    IEnumerator Press()
    {
        yield return new WaitForSeconds(0.5f);
        pressing = false;
    }
}

