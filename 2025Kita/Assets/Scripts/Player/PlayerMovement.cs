using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float moveForce = 5f;    // 移動するための力の強さ
    public float jumpPower = 200f;  // ジャンプ力
    public float rate = 0.3f;

    float moveHorizontal;           // 水平方向
    float moveVertical;             // 垂直方向
    private bool isJumping = false; // ジャンプ中かどうか
    public bool ready = true;       //ゲーム開始前かどうか
    public bool isStopMovement = false;   // 動きを止めるかどうかのフラグ
    public bool isGoal = false;
    CameraChange cameraChange;

    [SerializeField] public GameObject crackedEgg;  // 割れた後のオブジェクト

    PlayerStatus status;
    [SerializeField] private Pause pause;
    public GameObject friedEgg;     // 目玉焼き
    private AudioSource audioSource;
    public event Action<GameObject> OnEggCollided;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<PlayerStatus>();
        if(friedEgg != null)
        {
            audioSource = friedEgg.GetComponent<AudioSource>();
        }
        GetComponent<ClearConditions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready) return;

        if (status != null && status.HP <= 0) // HPが0になると動かなくなる
        {
            if(rb != null)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                rb.angularVelocity = Vector3.zero;
                moveForce = 0;
            }
            moveForce = 0;            
            return;
        }

        if (isStopMovement) return;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            //velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z*rate);  // ジャンプ
            isJumping = true;
        }

    }

    private void FixedUpdate()
    {
        if(status.HP <= 0 || isStopMovement)
        {
            return;
        }

        float moveMultiplier;
        if (!isJumping) moveMultiplier = 1.0f;
        else moveMultiplier = 0.6f; // ジャンプの時は移動速度を遅くする

        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical) * moveForce * moveMultiplier; // 移動させるための力の大きさ


        rb.AddForce(movement);  // 移動

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Field"))
        {
            isJumping = false;
        }
        if (collision.gameObject.tag == "Death")
        {
            status.HP = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            this.gameObject.SetActive(false);
            crackedEgg.SetActive(true);
            crackedEgg.transform.position = this.gameObject.transform.position;
            friedEgg.SetActive(true);
            audioSource.Play();
            ClearConditions.clearFlag++;
        }
        if (other.gameObject.tag == "Death")
        {
            status.HP = 0;
        }

        /*if(other.gameObject.CompareTag("ChangeEgg"))
        {
            OnEggCollided?.Invoke(other.gameObject);
        }*/
    }


    public void SetMoveStop(bool isStopped)
    {
        this.isStopMovement = isStopped;

        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null) return;
        }
       
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
        if(isStopped)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    public void StopPlayer()
    {
        isStopMovement = true;
    }

    public void MovePlayer()
    {
        isStopMovement = false;
    }
}
