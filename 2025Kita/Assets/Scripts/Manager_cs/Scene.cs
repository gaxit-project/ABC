using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
    [SerializeField] private Sound sound;
    private bool quit = false;

    //Main�V�[���Ɉړ�
    public void ChangeMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void ChangeMainInvoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain", 0.3f);
    }
    public void ChangeMain2()
    {
        SceneManager.LoadScene("Main2");
    }
    public void ChangeMain2Invoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain2", 0.3f);
    }
    public void ChangeMain3()
    {
        SceneManager.LoadScene("Main3");
    }
    public void ChangeMain3Invoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain3", 0.3f);
    }
    public void ChangeMain4()
    {
        SceneManager.LoadScene("Main4");
    }
    public void ChangeMain4Invoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain4", 0.3f);
    }
    public void ChangeSelect()
    {
        ReadyManager.ResetReady();
        SceneManager.LoadScene("SelectStage");
    }
    public void ChangeSelectInvoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeSelect", 0.3f);
    }
    //Title�V�[���Ɉړ�
    public void ChangeTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void ChangeTitleInvoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeTitle", 0.3f);
    }
    //Clear�V�[���Ɉړ�
    public void ChangeClear()
    {
        SceneManager.LoadScene("Clear");
    }
    public void ChangeClearInvoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeClear", 0.3f);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private void PlaySE() 
    { 
        if (sound != null)
        {
            sound.PlayButton();
        } 
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
