using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButton : MonoBehaviour
{
    public float bottomY = -0.01f;   // ボタンの沈む最大座標
    public float speed = 0.1f;  // ボタンの移動速度
    [SerializeField] private GravityControl GC;
    [SerializeField] private CameraMovie2 CM;
    [SerializeField] private GameObject Camera;
    [SerializeField] private PlayerMovement PM;

    private float startY;   // ボタンの初期Y座標
    private bool isPlayerTouching = false;  // プレイヤーが触れているか (押されている状態か)
    private Sound sound;

    void Start()
    {
        startY = transform.position.y;  // 初期位置を保存
        sound = GetComponent<Sound>(); 
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

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = true;
            GetComponent<Renderer>().material.color = Color.green;
            GC.PressButton();
            Camera.gameObject.SetActive(true);
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                StartCoroutine(CM.CameraScene(pm));
            }
            sound.PlayButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerTouching = false;
        GetComponent<Renderer>().material.color = Color.white;
        GC.ReleaseButton();
    }
}
