using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearConditions : MonoBehaviour
{
    public int clearCondition = 1;  // クリアするために必要な条件
    public static int clearFlag = 0;

    private void Start()
    {
        clearFlag = 0; // フラグを初期化
    }

    // Update is called once per frame
    void Update()
    {
        if (clearCondition == clearFlag)
        {
            Invoke(nameof(SceneChange), 3.0f);
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("Clear");
    }


}
