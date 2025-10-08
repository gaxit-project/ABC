using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public GameObject startpoint;　// スタート位置
    PlayerStatus status;

    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(status.HP <= 0)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                this.transform.position = startpoint.transform.position;            
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // ロードする
            }
        }
    }
}
