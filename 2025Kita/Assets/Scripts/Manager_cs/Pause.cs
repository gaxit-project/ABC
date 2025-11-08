using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private StageCamera sc;

    public bool isPaused = false;

    //ポーズ画面を開くかどうか判断
    public void PauseGame()
    {
        if (!isPaused)
        {
            StartPause();
        }
        else if(isPaused)
        {
            ClosePause();
        }
    }

    //ポーズ画面を開く
    public void StartPause()
    {
        Time.timeScale = 0;

        pauseMenu.SetActive(true);

        isPaused = true;
    }

    //ポーズ画面を閉じる
    public void ClosePause()
    {
        Time.timeScale = 1;

        pauseMenu.SetActive(false);

        isPaused = false;
    }
}
