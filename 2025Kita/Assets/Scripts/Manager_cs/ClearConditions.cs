using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ClearConditions : MonoBehaviour
{
    public int clearCondition = 1;  // クリアするために必要な条件
    public static int clearFlag = 0;
    CameraChange cameraChange;
    public AudioSource clearSE;
    private bool isCleared;

    private void Start()
    {
        clearFlag = 0; // フラグを初期化
    }


    void Update()
    {
        if (clearFlag >= clearCondition && !isCleared)
        {
            isCleared = true;
            clearSE.Play();
            Invoke(nameof(SceneChange), 3.0f);
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("Clear");
    }


}
