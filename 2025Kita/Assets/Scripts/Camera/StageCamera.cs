using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class StageCamera : MonoBehaviour
{
    [SerializeField] private Transform startPoint;  //スタート地点
    [SerializeField] private Transform[] points;
    [SerializeField] private float moveSpeed = 1f;  //カメラの移動スピード
    [SerializeField] private float rotationSpeed = 3f;  //カメラの向きが変わる速さ
    [SerializeField] GameObject[] playerCamera;

    public bool skip = false;

    //スタート前のカメラ移動処理
    public IEnumerator IntroCamera()
    {
        //バグが起きないため
        yield return null; // 保険で1フレーム待機

        if (!gameObject.activeInHierarchy)
            yield break;


        for(int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(false);
        }
        

        Time.timeScale = 0;

        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;

        yield return new WaitForSecondsRealtime(2f);

        for (int i = 0; i < points.Length; i++)
        {
            if(skip) break;
            Transform target = points[i];
            while (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                if (skip) break;
                //向きを変える処理
                /*
                Vector3 direction = (target.position - transform.position).normalized;
                if (direction.magnitude > 0.001f)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        lookRotation,
                        rotationSpeed * Time.unscaledDeltaTime
                    );
                }*/

                // 移動処理
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.position,
                    moveSpeed * Time.unscaledDeltaTime
                );
                yield return null;
            }
        }

        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;

        for(int i = 0; i < playerCamera.Length; i++)
        {
            playerCamera[i].SetActive(true);
        }
        gameObject.SetActive(false);
    }

    
}
