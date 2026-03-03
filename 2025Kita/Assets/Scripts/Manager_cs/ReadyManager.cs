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

    private static bool reload = false;     //任意のステージを1度遊んだかどうかのフラグ
    public bool isReady = true;     //ステージ前に一時停止するかどうかのフラグ

    //ステージ開始前に強制的に実行
    private IEnumerator Start()
    {
        if (reload)     //同じステージをもう一度始める場合
        {
            text.text = "";
            isReady = false;
            Time.timeScale = 1f;
            sc.gameObject.SetActive(false);
            if(player != null)
            {
                player.ready = true;
            }
        }
        else if(!reload)    //セレクト画面から移動した場合
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

    //ステージ開始前の待ち
    private IEnumerator ReadyStart()
    {
        int count = 3;

        Time.timeScale = 0;

        if(player != null)
        {
            player.ready = false;
        }

        //カウントダウン開始
        while(count > 0)
        {
            text.text = "Ready...";
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        yield return new WaitUntil(() => !pause.isPaused);

        //カウントダウン終了
        text.text = "Start!";
        yield return new WaitForSecondsRealtime(1f);
        text.gameObject.SetActive(false);

        Time.timeScale = 1;

        isReady = false;

        if (player != null)
        {
            player.ready = true;
        }

        reload = true;      //1度任意のステージを遊んだ

    }

    //ステージ開始前の目的表示
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

    //外部からのリセットメソッド
    public static void ResetReady()
    {
        reload = false;
    }

    //ステージ演出のスキップの許可
    public void SkipCamera()
    {
        sc.skip = true;
    }
}
