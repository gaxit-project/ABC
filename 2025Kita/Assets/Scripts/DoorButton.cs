using UnityEngine;
using System.Collections;

public class DoorButton : MonoBehaviour
{
    // ボタンの沈む限界Y座標 (絶対値)
    public float bottomY = -0.01f;
    // ボタンの移動速度
    public float speed = 0.1f;
    // 関連付けるドアのスクリプト
    public MoveDoor door;

    // ボタンの初期Y座標 (元の高さ)
    private float startY;
    // プレイヤーが触れているか (押されている状態か)
    private bool isPlayerTouching = false;

    void Start()
    {
        // ボタンの初期位置を保存しておく
        startY = transform.position.y;
    }

    void Update()
    {
        // プレイヤーが触れていればボタンを沈める処理
        if (isPlayerTouching)
        {
            // 目標位置 (bottomY) に向かってY座標を減少させる
            if (transform.position.y > bottomY)
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;

                // ボタンが目標位置を超えないようにクランプする
                if (transform.position.y <= bottomY)
                {
                    transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
                }
            }

            // ボタンが完全に沈んでいる（目標位置にある）場合のみドアを開ける
            // (ここではボタンが少しでも沈み始めたら開く設定でも良い)
            if (transform.position.y <= bottomY)
            {
                door.isOpen = true; // ドアを開ける
            }
        }
        // プレイヤーが触れていなければボタンを元の位置に戻す処理
        else
        {
            // 初期位置 (startY) に向かってY座標を増加させる
            if (transform.position.y < startY)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;

                // ボタンが初期位置を超えないようにクランプする
                if (transform.position.y >= startY)
                {
                    transform.position = new Vector3(transform.position.x, startY, transform.position.z);
                }
            }

            // ボタンが元の位置に戻ったらドアを閉める
            if (transform.position.y >= startY)
            {
                door.isOpen = false; // ドアを閉める
            }
        }
    }

    // プレイヤーがボタンのコライダーに接触を開始したとき
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerTouching = true; // 押されている状態にする
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    // プレイヤーがボタンのコライダーから離れたとき
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerTouching = false; // 押されていない状態にする
            GetComponent<Renderer>().material.color = Color.white; // 色を元に戻すなど
        }
    }
}