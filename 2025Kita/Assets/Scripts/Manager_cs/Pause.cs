using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;

    private PlayerInput playerInput;

    private bool isPaused = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseGame();
        }
        
    }

    //ポーズ画面を開く
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
