using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPausing = false;

    //ポーズ画面を開く
    public void PauseGame()
    {
        if (isPausing)
        {
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("ポーズ画面を開いている");
        }
    }

    //ポーズ画面を閉じる
    public void ClosePause()
    {
        if(!isPausing)
        {
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("ポーズ画面を閉じている");
        }
    }
}
