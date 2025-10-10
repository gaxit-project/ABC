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
            Food_EggRenderer.enabled = false;

            crackedEgg.SetActive(true);
            crackedEgg.transform.position = egg.transform.position;
            
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // ロードする
            }
        }
    }
}
