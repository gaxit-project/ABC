using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Pause pause;
    [SerializeField] private StageCamera sc;

    private static bool reload = false;

    private IEnumerator Start()
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
            if (sc != null)
            {
                yield return StartCoroutine(sc.IntroCamera());
            }
            if(text != null)
            {
                yield return StartCoroutine(ShowPurpose());
                yield return StartCoroutine(ReadyStart());
            }
        }
    }

    //スタート前のカウントダウン
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

        yield return new WaitUntil(() => !pause.isPaused);

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

    //スタート前の目的表示
    private IEnumerator ShowPurpose()
    {
        int count = 3;
        Time.timeScale = 0;

        while(count > 0)
        {
            text.text = "フライパンに飛び込め！";
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }
        
    }

    //もう一度シーンを読み込むか
    public static void ResetReady()
    {
        reload = false;
    }

    //スキップボタンが押されたか
    public void SkipCamera()
    {
        sc.skip = true;
    }
}
