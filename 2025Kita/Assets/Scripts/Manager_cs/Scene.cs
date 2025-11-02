using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
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
        Time.timeScale = 1;
        SceneManager.LoadScene("SelectStage");
    }

    //Titleシーンに移動
    public void ChangeTitle()
    {
        ReadyManager.ResetReady();
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
}
