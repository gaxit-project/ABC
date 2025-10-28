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
    private PlayerMovement currentScript;   // 現在動いているプレイヤーのスクリプト

    // Start is called before the first frame update
    void Start()
    {
        // 配列初期化
        if(targetScripts.Length > 0 && targetScripts[0] != null)
        {
            currentScript = targetScripts[0];
            currentScript.enabled = true;
        }

        for(int i=0; i<cameras.Length; i++)
        {
            if (i!=0)   // 使用中のスクリプト以外は非アクティブにしておく
            {
                if (cameras[i] != null)
                {
                    cameras[i].SetActive(false);
                }

                if(targetScripts.Length > i && targetScripts[i] != null)
                {
                    targetScripts[i].enabled = false;
                }
            }        
            
        }

        currentScript.enabled = true;               // 現在使用しているオブジェクトのスクリプトをアクティブ状態にする
        mainCamera = GameObject.Find("Camera_1");
        mainCamera.SetActive(true);                 // 現在使用しているカメラをアクティブ状態にする
    }

    // 卵を選択
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EggChange(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EggChange(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EggChange(3);
        }
    }

    /// <summary>
    ///  プレイヤー変更（現在使用しているものを非アクティブにし、選択されたものをアクティブにする）
    /// </summary>
    /// <param name="num"></param>
    private void EggChange(int num)
    {
        mainCamera.SetActive(false);
        mainCamera = cameras[num-1];
        cameras[num-1].SetActive(true);
        currentScript.enabled = false;
        currentScript = targetScripts[num-1];
        currentScript.enabled = true;
    }
}
