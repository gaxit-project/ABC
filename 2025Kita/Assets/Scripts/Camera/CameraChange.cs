using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    public GameObject[] cameras;            // 使用するカメラ
    public GameObject[] farCameras;      // 引きに使用するカメラ
    public GameObject mainCamera;           // 使用中カメラ
    public PlayerMovement[] targetScripts;  // プレイヤー移動を管理するスクリプト
    public PlayerMovement currentScript;   // 現在動いているプレイヤーのスクリプト
    private int EggSelect = 0;
    private bool isFarView = false;
    public bool isStopChange = false;

    // Start is called before the first frame update
    void Start()
    {
        int startIndex = Mathf.Clamp(EggSelect, 0, targetScripts.Length - 1);

        if (targetScripts.Length > startIndex)
        {
            currentScript = targetScripts[startIndex];
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            CinemachineVirtualCamera vcam = cameras[i].GetComponent<CinemachineVirtualCamera>();

            if (vcam != null)
            {
                vcam.Priority = (i == startIndex) ? 15 : 5;
            }

            if (targetScripts.Length > i && targetScripts[i] != null)
            {
                targetScripts[i].SetMoveStop(i != startIndex);
            }
        }

        if (currentScript != null)
        {
            SubscribeToPlayerCollision(currentScript);
        }
    }

    /// <summary>
    /// コントローラー切り替え
    /// </summary>
    public void quail()
    {
        EggChange(2);
    }

    public void chicken()
    {
        EggChange(0);
    }

    public void ostrich()
    {
        EggChange(1);
    }

    /// <summary>
    /// キーボード切り替え
    /// </summary>
    private void Update()
    {
        if (isStopChange) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            EggSelect = (EggSelect + 1) % targetScripts.Length;
            EggChange(EggSelect);
        }
        if (Input.GetButton("FarCamera"))
        {
            ChangeCameraView(true);
        }
        else
        {
            ChangeCameraView(false);
        }
    }

    private void SubscribeToPlayerCollision(PlayerMovement player)
    {
        player.OnEggCollided += HandleCollisionFromChild;
    }

    private void UnsubscribeFromPlayerCollision(PlayerMovement player)
    {
        player.OnEggCollided -= HandleCollisionFromChild;
    }

    /// <summary>
    ///  プレイヤー変更（現在使用しているものを非アクティブにし、選択されたものをアクティブにする）
    /// </summary>
    /// <param name="num"></param>
    private void EggChange(int num)
    {
        if (isStopChange) return;

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].GetComponent<CinemachineVirtualCamera>().Priority = 5;
            farCameras[i].GetComponent<CinemachineVirtualCamera>().Priority = 5;
        }

        if (currentScript != null)
        {
            UnsubscribeFromPlayerCollision(currentScript);

            currentScript.SetMoveStop(true);

            GameObject oldCameraObject = cameras[Array.IndexOf(targetScripts, currentScript)];
            CinemachineVirtualCamera oldVcam = oldCameraObject.GetComponent<CinemachineVirtualCamera>();

            if (oldVcam != null)
            {
                oldVcam.Priority = 5;
            }
        }

        if (num < cameras.Length && num < targetScripts.Length)
        {
            currentScript = targetScripts[num];

            GameObject newCameraObject = cameras[num];
            CinemachineVirtualCamera newVcam = newCameraObject.GetComponent<CinemachineVirtualCamera>();

            if (newVcam != null)
            {
                newVcam.Priority = 15;
            }
            currentScript.SetMoveStop(false);
            SubscribeToPlayerCollision(currentScript);

            cameras[num].GetComponent<CinemachineVirtualCamera>().Priority = 15;
            isFarView = false;
        }
    }


    private void HandleCollisionFromChild(GameObject collodedObject)
    {
        if (collodedObject != null)
        {
            collodedObject.SetActive(false);
        }
        EggSelect = (EggSelect + 1) % targetScripts.Length;
        EggChange(EggSelect);
    }

    private void ChangeCameraView(bool far)
    {
        int index = Array.IndexOf(targetScripts, currentScript);
        if (index < 0) return;

        var normalVcam = cameras[index].GetComponent<CinemachineVirtualCamera>();
        var farVcam = farCameras[index].GetComponent<CinemachineVirtualCamera>();

        if (normalVcam != null)
            normalVcam.Priority = far ? 5 : 15;

        if (farVcam != null)
            farVcam.Priority = far ? 15 : 5;

        isFarView = far;
    }

    public void StopChange()
    {
        isStopChange = true;
    }

    public void MoveChange()
    {
        isStopChange = false;
    }
}
