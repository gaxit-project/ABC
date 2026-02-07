using UnityEngine;
using System.Collections;

public class DoorButton : MonoBehaviour
{
    public float bottomY = -0.01f;   // ボタンの沈む最大座標
    public float speed = 0.1f;  // ボタンの移動速度
    public MoveDoor door;
    [SerializeField] private CameraMovie2 CM;
    [SerializeField] private GameObject Camera;
    [SerializeField] private PlayerMovement PM;

    private float startY;   // ボタンの初期Y座標
    private bool isPlayerTouching = false;  // プレイヤーが触れているか (押されている状態か)

    public GameObject scaffold; // 出現する足場

    void Start()
    {
        startY = transform.position.y;  // 初期位置を保存
        scaffold.SetActive(false);
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
                door.isOpen = true;
                
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
                door.isOpen = false; 
            }
        }
    }

    /// <summary>
    /// 接触した時の処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = true;
            GetComponent<Renderer>().material.color = Color.green;
            scaffold.SetActive(true);
            Camera.gameObject.SetActive(true);
            StartCoroutine(CM.CameraScene());
            //PM.MovePlayer();
        }
       
    }

    /// <summary>
    /// 接触が外れた時の処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        isPlayerTouching = false; 
        GetComponent<Renderer>().material.color = Color.white; 
        scaffold.SetActive(false);
    }
}