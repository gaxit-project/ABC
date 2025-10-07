using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveForce = 5f;   // 移動するための力の強さ
    public float jampPower = 200f;          // ジャンプ力
    float moveHorizontal;           // 水平方向
    float moveVertical;             // 垂直方向

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveForce; // 移動させるための力の大きさ
        rb.AddForce(movement);  // 移動

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jampPower;  // ジャンプ
        }
    }

    
}
