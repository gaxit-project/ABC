using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveForce = 5f;    // 移動するための力の強さ
    public float jumpPower = 200f;  // ジャンプ力
    float moveHorizontal;           // 水平方向
    float moveVertical;             // 垂直方向
    private bool isJumping = false; // ジャンプ中かどうか
    PlayerStatus status;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || (Input.GetButtonDown("Fire1")))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // ロードする
        }

        if (status.HP <= 0) // HPが0になると動かなくなる
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.angularVelocity = Vector3.zero;
            moveForce = 0;

            if(!rb.isKinematic)
            {
                rb.isKinematic = true;
            }

            return;
        }

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;  // ジャンプ
            isJumping = true;
        }

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical) * moveForce; // 移動させるための力の大きさ
  

        rb.AddForce(movement);  // 移動
        transform.LookAt(transform.position);

    }

    private void OnCollisionEnter(Collision collision)  // 地面との接触判定
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Field"))
        {
            isJumping = false;           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("Clear");
        } 
    }
}
