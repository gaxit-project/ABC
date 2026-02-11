using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] private int stageIndex;

    private void Awake()
    {
        PlayerPrefs.SetInt("LastPlayedStage", stageIndex);
        PlayerPrefs.Save(); // –Y‚ê‚¸‚É•Û‘¶
    }
}
