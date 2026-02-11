using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public static SelectManager Instance;

    [SerializeField] private GameObject[] buttons;
    [SerializeField] private EventSystem eventSystem;
    public bool[] playedStage;

    private void Start()
    {
        //初期化
        for(int i  = 0; i < playedStage.Length;  i++)
        {
            playedStage[i] = false;
        }

        // 最後にプレイしたステージを取得
        int lastStage = PlayerPrefs.GetInt("LastPlayedStage", 0); // デフォルト0
        playedStage[lastStage] = true;

        // EventSystemで最初に選択するボタンを設定
        eventSystem.firstSelectedGameObject = buttons[lastStage];
    }

}
