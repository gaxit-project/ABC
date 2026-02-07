using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovie : MonoBehaviour
{
    [SerializeField] GameObject[] playerCamera;
    [SerializeField] PlayerMovement PM;
    [SerializeField] StopPressMachine2 SPM;

    public IEnumerator CameraScene()
    {
        

        yield return null; // •ÛŒ¯‚Å1ƒtƒŒ[ƒ€‘Ò‹@

        for (int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(false);
        }

        PM.StopPlayer();

        //yield return new WaitForSecondsRealtime(2f);
        while (!SPM.RtnwasStop())
        {
            if (!SPM.RtnisStop())
            {
                break;
            }
        }
        yield return new WaitForSecondsRealtime(2f);

        for (int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(true);
        }

        this.gameObject.SetActive(false);
    }
}
