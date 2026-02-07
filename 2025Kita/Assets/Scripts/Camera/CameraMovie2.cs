using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovie2 : MonoBehaviour
{
    [SerializeField] GameObject[] playerCamera;
    [SerializeField] PlayerMovement PM;
    [SerializeField] float sceneTime = 4f;

    public IEnumerator CameraScene()
    {
        yield return null; // ï€åØÇ≈1ÉtÉåÅ[ÉÄë“ã@

        StartCoroutine(CameraScene1());

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(CameraScene2());
    }

    private IEnumerator CameraScene1()
    {
        yield return null;

        for (int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(false);
        }

        PM.StopPlayer();

        //yield return new WaitForSecondsRealtime(2f);
        yield return new WaitForSecondsRealtime(sceneTime);



        for (int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(true);
        }

        this.gameObject.SetActive(false);
    }

    private IEnumerator CameraScene2()
    {
        yield return null;

        PM.MovePlayer();
    }
}
