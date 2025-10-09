using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void ChangeMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void ChangeTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ChangeClear()
    {
        SceneManager.LoadScene("Clear");
    }
}
