using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject playerObj;    // プレイヤーのオブジェクト
    private Vector3 offset;         // カメラとプレイヤーの距離
    public float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        offset = gameObject.transform.position - playerObj.transform.position;
    }

    private void LateUpdate()
    {
        
        gameObject.transform.position = playerObj.transform.position + offset;
        transform.position = playerObj.transform.position + offset;
    }
}
