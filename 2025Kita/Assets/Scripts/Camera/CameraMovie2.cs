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
        

        yield return null; // •ÛŒ¯‚Å1ƒtƒŒ[ƒ€‘Ò‹@

        for (int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(false);
        }

        PM.StopPlayer();

        //yield return new WaitForSecondsRealtime(2f);
        yield return new WaitForSecondsRealtime(sceneTime);

        PM.MovePlayer();

        for (int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(true);
        }

        this.gameObject.SetActive(false);
    }
}
