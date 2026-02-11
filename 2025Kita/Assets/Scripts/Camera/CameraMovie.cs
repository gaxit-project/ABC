using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovie : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] movieCameras; // 演出用カメラ
    //[SerializeField] PlayerMovement PM;
    [SerializeField] CameraChange CC;
    [SerializeField] StopPressMachine2 SPM;
    [SerializeField] private float sceneTime;

    private int[] defaultPriorities;

    private void Awake()
    {
        // 元の Priority を保存
        defaultPriorities = new int[movieCameras.Length];
        for (int i = 0; i < movieCameras.Length; i++)
        {
            defaultPriorities[i] = movieCameras[i].Priority;
        }
    }

    public IEnumerator CameraScene(PlayerMovement pm)
    {
        SPM.isStop = true;

        yield return null; // 保険で1フレーム待機

        // 演出用カメラを最優先に
        for (int i = 0; i < movieCameras.Length; i++)
        {
            movieCameras[i].Priority = 30;
        }

        pm.StopPlayer();
        CC.StopChange();
        
        yield return new WaitForSecondsRealtime(sceneTime);

        // Priorityを元に戻す
        for (int i = 0; i < movieCameras.Length; i++)
        {
            movieCameras[i].Priority = defaultPriorities[i];
        }

        pm.MovePlayer();
        CC.MoveChange();

        //this.gameObject.SetActive(false);
    }
}
