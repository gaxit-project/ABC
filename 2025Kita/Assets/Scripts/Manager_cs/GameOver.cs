using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public GameObject startpoint;　// スタート位置
    [SerializeField] public GameObject egg;         // 割れる前のオブジェクト
    [SerializeField] public GameObject crackedEgg;  // 割れた後のオブジェクト
    PlayerStatus status;
    public MeshRenderer Food_EggRenderer;
    public float roadTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        status = GetComponentInChildren<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(status.HP <= 0)
        {
            egg.SetActive(false);
            crackedEgg.SetActive(true);
            crackedEgg.transform.position = egg.transform.position;

            Invoke(nameof(SceneChange), roadTime);  // roadTImeで設定した時間が経つとシーン移動する
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // ロードする
    }
}
