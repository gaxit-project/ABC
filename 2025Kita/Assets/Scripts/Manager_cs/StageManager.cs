using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    //public int clearedStage = 0;

    [SerializeField] private AudioSource startSE;
    [SerializeField] int lastStageNumber = 6; // 最終ステージ番号

    public int lastClearedStageNumber;

    private int currentStageNumber = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //clearedStage = PlayerPrefs.GetInt("ClearedStage", 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ClearStage(int stageNumber)
    {
        int currentStageNumber = stageNumber;
    }

    // 🔥 今いるステージ番号を渡す
    public void LoadNextStage()
    {
        currentStageNumber = lastClearedStageNumber;
        Debug.Log("Current Stage: " + currentStageNumber);

        if (currentStageNumber >= lastStageNumber)
        {
            SceneManager.LoadScene("AllClear");
        }
        else
        {
            StartCoroutine(NextScene(currentStageNumber));
        }

    }

    private IEnumerator NextScene(int currentStageNumber)
    {
        yield return new WaitForSeconds(1.0f);

        if (startSE != null)
            startSE.Play();

        yield return new WaitForSeconds(startSE.clip.length);

        Time.timeScale = 1;
        SceneManager.LoadScene("Main" + (currentStageNumber + 1));
    }

}

