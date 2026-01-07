using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;

public class SinkingBlock : MonoBehaviour
{
    private Rigidbody rigidBody;        
    private Vector3 defaultPosition;    // 初期位置
    private Vector3 velocity;           // 移動速度
    [SerializeField]
    private float rayDistance = 1f; // 飛ばすレイの距離
    private Collider myCollider;
    [SerializeField]
    private Collider floorCollider; // 接触を無視するコライダ
    [SerializeField]
    private float returnSpeed = 0.1f;   // 戻るスピード
    [SerializeField]
    private float sinkingSpeed = 2f;
    private bool characterIsOnBoard; // キャラが乗っているかどうか
    [SerializeField]
    private Vector3 blockSize = Vector3.one;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        defaultPosition = rigidBody.position;
        myCollider = GetComponent<Collider>();
        Physics.IgnoreCollision(myCollider, floorCollider, true);
    }

    void Update()
    {
        //　BoxとPlayerレイヤーを持つコライダと接触するか確認し、プレイヤーが乗っていれば下向き、
        if (!characterIsOnBoard)
        {
            if (Physics.CheckBox(transform.position + Vector3.up * rayDistance, blockSize * 0.52f, Quaternion.identity, LayerMask.GetMask("Player")))
            {
                velocity = Vector3.down * sinkingSpeed;
                characterIsOnBoard = true;
            }
            else
            {
                velocity = Vector3.up * returnSpeed;
            }
            //　キャラクターが乗っている時
        }
        else
        {
            // キャラクターが乗っているとされている時に、ボックスとキャラクターが接触しているか確認し、していなければ乗っていないに変更
            if (!Physics.CheckBox(transform.position + Vector3.up * rayDistance, blockSize * 0.52f, Quaternion.identity, LayerMask.GetMask("Player")))
            {
                characterIsOnBoard = false;
            }
        }
    }
    private void FixedUpdate()
    {
        //　移動が上向き（元に戻る向き）で初期位置以上の場合は移動させない
        if (velocity.y > 0f
            && rigidBody.position.y >= defaultPosition.y
            )
        {
            //　完全に移動させる
            rigidBody.MovePosition(defaultPosition);
            return;
        }
        rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
    }


    /*private bool isBlockTouch = false;
    private float fallCount = 0f;  // 床が落ちるまでの時間
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        //Debug.Log(gameObject.name + "が初期化されました。重力はオフです。");
    }

    // Update is called once per frame
    void Update()
    {
        if(isBlockTouch == true)
        {
            fallCount += Time.deltaTime;

            if (fallCount >= 3.0f)
            {
                DownBlock();
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(isBlockTouch == false)
            {
                fallCount = 0;
                isBlockTouch = true;
                //Debug.Log("--- プレイヤー接触! カウント開始 ---");
            }
        }
    }

    void DownBlock()
    {
        if (rb.useGravity == false)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.useGravity = true;
            isBlockTouch = false;

            //Debug.Log("!!! 3秒経過! 落下処理を実行しました !!!");
        }

    }*/
}
