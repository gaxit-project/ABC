using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraChange : MonoBehaviour
{
    public GameObject[] cameras;            // 使用するカメラ
    public GameObject mainCamera;           // 使用中カメラ
    public PlayerMovement[] targetScripts;  // プレイヤー移動を管理するスクリプト
    public PlayerMovement currentScript;   // 現在動いているプレイヤーのスクリプト
    private int EggSelect = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            // 使用中のスクリプト以外は非アクティブにしておく
            cameras[i].SetActive(false);

            if (i != 0)
            {
                if (targetScripts.Length > i && targetScripts[i] != null)
                {
                    targetScripts[i].enabled = false;
                }
            }
        }

        currentScript.enabled = true;               // 現在使用しているオブジェクトのスクリプトをアクティブ状態にする
        mainCamera.SetActive(true);                 // 現在使用しているカメラをアクティブ状態にする
    }

    // 卵を選択
    // Update is called once per frame
    void Update()
    {
        Debug.Log("卵選択可能");

        if (currentScript.flag == 1)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                EggSelect++;
                EggChange(EggSelect % 3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                EggChange(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                EggChange(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                EggChange(2);
            }
        }
    }

    /// <summary>
    ///  プレイヤー変更（現在使用しているものを非アクティブにし、選択されたものをアクティブにする）
    /// </summary>
    /// <param name="num"></param>
    private void EggChange(int num)
    {
        mainCamera.SetActive(false);
        mainCamera = cameras[num];
        cameras[num].SetActive(true);
        currentScript.enabled = false;
        currentScript = targetScripts[num];
        currentScript.enabled = true;
        currentScript.flag = 0;
        Debug.Log("卵選択完了");
    }
}
