using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovie2 : MonoBehaviour
{
    [SerializeField] GameObject[] playerCamera;
    [SerializeField] PlayerMovement PM;
    [SerializeField] private CameraChange CC;
    [SerializeField] float sceneTime = 4f;

    public IEnumerator CameraScene()
    {
        yield return null; // ï€åØÇ≈1ÉtÉåÅ[ÉÄë“ã@
        PM.StopPlayer();
        CC.StopChange();
        StartCoroutine(CameraScene1());
        yield return new WaitForSeconds(sceneTime);
        PM.MovePlayer();
        CC.MoveChange();
    }

    private IEnumerator CameraScene1()
    {

        for (int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(false);
        }

        

        //yield return new WaitForSecondsRealtime(2f);
        yield return new WaitForSecondsRealtime(sceneTime);



        for (int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(true);
        }

        this.gameObject.SetActive(false);
        //yield return null;
    }


}
