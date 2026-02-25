using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    [SerializeField] private Image fadePanel;             // フェード用のUIパネル（Image）
    [SerializeField] private float fadeDuration = 1.0f;   // フェードの完了にかかる時間
    [SerializeField] private Canvas normalCanvas;
    [SerializeField] private GameObject quitCanvas;
    [SerializeField] private Button firstQuitButton;
    [SerializeField] private Button secondQuitButton;
    [SerializeField] private Sound sound;
    [SerializeField] private float time = 0.2f;
    private bool quit = false;

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
        SceneManager.LoadScene(sceneName);
    }

    //シーン移動処理
    private void ChangeScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }
    //Mainシーン移動
    private void ChangeMain()
    {
        ChangeScene("Main");
    }
    public void ChangeMainInvoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain", time);
    }
    //Main2シーン移動
    private void ChangeMain2()
    {
        ChangeScene("Main2");
    }
    public void ChangeMain2Invoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain2", time);
    }
    //Main3シーン移動
    private void ChangeMain3()
    {
        ChangeScene("Main3");
    }
    public void ChangeMain3Invoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain3", time);
    }
    //Main4シーン移動
    private void ChangeMain4()
    {
        ChangeScene("Main4");
    }
    public void ChangeMain4Invoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain4", time);
    }
    //Main5シーン移動
    private void ChangeMain5()
    {
        ChangeScene("Main5");
    }
    public void ChangeMain5Invoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain5", time);
    }
    //Main6シーン移動
    private void ChangeMain6()
    {
        ChangeScene("Main6");
    }
    public void ChangeMain6Invoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeMain6", time);
    }
    //SelectStageシーン移動
    private void ChangeSelect()
    {
        ReadyManager.ResetReady();
        ChangeScene("SelectStage");
    }
    public void ChangeSelectInvoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeSelect", time);
    }
    //Titleシーン移動
    private void ChangeTitle()
    {
        ChangeScene("Title");
    }
    public void ChangeTitleInvoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeTitle", time);
    }
    //Clearシーン移動
    private void ChangeClear()
    {
        ReadyManager.ResetReady();
        ChangeScene("Clear");
    }
    public void ChangeClearInvoke()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke("ChangeClear", time);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReStart()
    {
        PlaySE();
        Time.timeScale = 1;
        Invoke(nameof(SceneChange), time);
    }
    private void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // ロードする
    }
    //SE鳴らす処理
    private void PlaySE() 
    { 
        if (sound != null)
        {
            sound.PlayButton();
        } 
    }
    //ゲーム終了ボタン表示処理
    public void Announce()
    {
        if(!quit)
        {
            quitCanvas.gameObject.SetActive(true);
            normalCanvas.gameObject.SetActive(false);
            //normalCanvas.GetComponent<GraphicRaycaster>().enabled = false;
            EventSystem.current.SetSelectedGameObject(firstQuitButton.gameObject);
            quit = true;
        }
        else
        {
            quitCanvas.gameObject.SetActive(false);
            normalCanvas.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(secondQuitButton.gameObject);
            quit = false;
        }
    }
}
