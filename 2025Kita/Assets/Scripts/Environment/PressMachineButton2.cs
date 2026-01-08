using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PressMachineButton2 : MonoBehaviour
{
    public float bottomY = -0.01f;   // ボタンの沈む最大座標
    public float speed = 0.1f;  // ボタンの移動速度
    public StopPressMachine2 sPM;

    private float startY;   // ボタンの初期Y座標
    private bool isPlayerTouching = false;  // プレイヤーが触れているか (押されている状態か)

    void Start()
    {
        startY = transform.position.y;  // 初期位置を保存
    }

    void Update()
    {
        if (isPlayerTouching)
        {
            if (transform.position.y > bottomY) // ボタンが沈む処理
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;

                if (transform.position.y <= bottomY)
                {
                    transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
                }
            }

            // ボタンが完全に沈んでいる（目標位置にある）場合のみドアを開ける
            if (transform.position.y <= bottomY)
            {
                sPM.isStop = true; // プレス機を止める
            }
        }
        else // 触れていなければ元の位置に戻る
        {
            if (transform.position.y < startY)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;

                if (transform.position.y >= startY)
                {
                    transform.position = new Vector3(transform.position.x, startY, transform.position.z);
                }
            }

            if (transform.position.y >= startY)
            {
                sPM.isStop = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "quail_egg")
        {
            isPlayerTouching = true;
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "quail_egg")
        {
            isPlayerTouching = false;
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
