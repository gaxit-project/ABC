using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    [SerializeField] private Canvas normalCanvas;
    [SerializeField] private GameObject quitCanvas;
    [SerializeField] private Button firstQuitButton;
    [SerializeField] private Button secondQuitButton;
    private bool quit = false;

    //Mainシーンに移動
    public void ChangeMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
    public void ChangeMain2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main2");
    }
    public void ChangeMain3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main3");
    }

    public void ChangeSelect()
    {
        ReadyManager.ResetReady();
        Time.timeScale = 1;
        SceneManager.LoadScene("SelectStage");
    }

    //Titleシーンに移動
    public void ChangeTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }

    //Clearシーンに移動
    public void ChangeClear()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Clear");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Announce()
    {
        if(!quit)
        {
            quitCanvas.gameObject.SetActive(true);
            normalCanvas.gameObject.SetActive(false);
            //normalCanvas.GetComponent<GraphicRaycaster>().enabled = false;
            EventSystem.current.SetSelectedGameObject(firstQuitButton.gameObject);
            quit = true;
        }
        else
        {
            quitCanvas.gameObject.SetActive(false);
            normalCanvas.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(secondQuitButton.gameObject);
            quit = false;
        }
    }
}
