using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private PlayerMovement player;

    private void Awake()
    {
        StartCoroutine(ReadyStart());
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

        //ゲーム開始したときの処理
        text.text = "Start!";
        yield return new WaitForSecondsRealtime(1f);
        text.gameObject.SetActive(false);

        Time.timeScale = 1;

        if(player != null)
        {
            player.ready = true;
        }
    }

}
