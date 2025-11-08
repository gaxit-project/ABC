using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Pause pause;
    [SerializeField] private ReadyManager readyManager;
    [SerializeField] private Scene scene;

    private PlayerInput playerInput;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        readyManager = GetComponent<ReadyManager>();
        pause = GetComponent<Pause>();
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(pause != null)
            {
                pause.PauseGame();
            }
        }

    }

    public void OnSkip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (readyManager != null)
            {
                readyManager.SkipCamera();
            }
        }
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            scene.Announce();
        }
    }
}
