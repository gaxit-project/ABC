using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    //Mainシーンに移動
    public void ChangeMain()
    {
        SceneManager.LoadScene("Main");
    }

    //Titleシーンに移動
    public void ChangeTitle()
    {
        SceneManager.LoadScene("Title");
    }

    //Clearシーンに移動
    public void ChangeClear()
    {
        SceneManager.LoadScene("Clear");
    }
}
