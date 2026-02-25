using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    //public int clearedStage = 0;

    [SerializeField] private Image fadePanel;             // フェード用のUIパネル（Image）
    [SerializeField] private float fadeDuration = 1.0f;   // フェードの完了にかかる時間
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
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene,UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // 🔥 Inspector未設定なら探す
        if (fadePanel == null)
        {
            GameObject obj = GameObject.Find("Panel");
            if (obj != null)
                fadePanel = obj.GetComponent<Image>();
        }

        if (fadePanel != null)
        {
            Color c = fadePanel.color;
            c.a = 0f;
            fadePanel.color = c;
            fadePanel.gameObject.SetActive(true);
        }
    }

    public void ClearStage(int stageNumber)
    {
        lastClearedStageNumber = stageNumber;
        Debug.Log("Cleared Stage: " + lastClearedStageNumber);
    }

    // 🔥 今いるステージ番号を渡す
    public void LoadNextStage()
    {
        currentStageNumber = lastClearedStageNumber;
        Debug.Log("Current Stage: " + currentStageNumber);

        if (currentStageNumber >= lastStageNumber)
        {
            StartCoroutine(FadeOutAndLoadScene("AllClear"));
        }
        else
        {
            string nextSceneName = "Main" + (lastClearedStageNumber + 1);
            StartCoroutine(FadeOutAndLoadScene(nextSceneName));
        }

    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }


    public IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        fadePanel.enabled = true;                 // パネルを有効化
        float elapsedTime = 0.0f;                 // 経過時間を初期化
        Color startColor = fadePanel.color;       // フェードパネルの開始色を取得
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // フェードパネルの最終色を設定

        // フェードアウトアニメーションを実行
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                        // 経過時間を増やす
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // フェードの進行度を計算
            fadePanel.color = Color.Lerp(startColor, endColor, t); // パネルの色を変更してフェードアウト
            yield return null;                                     // 1フレーム待機
        }

        fadePanel.color = endColor;  // フェードが完了したら最終色に設定

        if (startSE != null)
            startSE.Play();

        yield return new WaitForSeconds(startSE.clip.length);

        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

}

