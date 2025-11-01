using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    public GameObject forcusObject; // 焦点を当てるオブジェクト

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(
            forcusObject.transform.position,    // 焦点のオブジェクトの座標を取得
            Vector3.up,
            10f * Time.deltaTime    // 回転角度
            );

    }
}
