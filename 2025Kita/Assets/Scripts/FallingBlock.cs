using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class FallingBlock : MonoBehaviour
{
    private bool isBlockTouch = false;
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

    }
}
