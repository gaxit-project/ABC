using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraMovie2 : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] movieCameras; // 演出用カメラ
    //[SerializeField] PlayerMovement PM;
    [SerializeField] CameraChange CC;
    [SerializeField] float sceneTime = 4f;

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
        yield return null; // 保険

        pm.StopPlayer();
        CC.StopChange();

        // 演出用カメラを最優先に
        for (int i = 0; i < movieCameras.Length; i++)
        {
            movieCameras[i].Priority = 30;
        }

        yield return new WaitForSeconds(sceneTime);

        // Priorityを元に戻す
        for (int i = 0; i < movieCameras.Length; i++)
        {
            movieCameras[i].Priority = defaultPriorities[i];
        }

        pm.MovePlayer();
        CC.MoveChange();

        //gameObject.SetActive(false);
    }
}
