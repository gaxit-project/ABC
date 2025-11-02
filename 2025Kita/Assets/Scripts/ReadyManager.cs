using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Pause pause;

    private static bool reload = false;

    private void Start()
    {
        if (reload)
        {
            text.text = "";
            Time.timeScale = 1f;
            if(player != null)
            {
                player.ready = true;
            }
        }
        else
        {
            StartCoroutine(ReadyStart());
        }
    }

    private IEnumerator ReadyStart()
    {
        int count = 3;

        Time.timeScale = 0;

        if(player != null)
        {
            player.ready = false;
        }

        //ゲーム開始まで待機している間の処理
        while(count > 0)
        {
            text.text = "Ready...";
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        if (!pause.isPaused)
        {
            //ゲーム開始したときの処理
            text.text = "Start!";
            yield return new WaitForSecondsRealtime(1f);
            text.gameObject.SetActive(false);

            Time.timeScale = 1;

            if (player != null)
            {
                player.ready = true;
            }

            //シーンを1度読み込んでいる
            reload = true;
        }

    }

    public static void ResetReady()
    {
        reload = false;
    }
}
