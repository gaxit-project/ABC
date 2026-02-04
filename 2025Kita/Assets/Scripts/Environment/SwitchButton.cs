using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    public float bottomY = -0.01f;   // ボタンの沈む最大座標
    public float speed = 0.1f;  // ボタンの移動速度
    public bool isOn = false;
    public GameObject disObject; // けすゲームオブジェクト

    void Update()
    {
        if (isOn)
        {
            if (transform.position.y > bottomY) // ボタンが沈む処理
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;

                if (transform.position.y <= bottomY)
                {
                    transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
                }
            }
        }
       
    }

    /// <summary>
    /// 接触した時の処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        isOn = true;
        GetComponent<Renderer>().material.color = Color.green;
        disObject.SetActive(false);
    }
}
