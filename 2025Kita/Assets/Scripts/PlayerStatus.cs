using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int HP = 100;                                     //　プレイヤーのHP
    [SerializeField] private Transform rayPosition;          //　レイを飛ばす場所
    [SerializeField] private float rayRange = 0.85f;         //　レイを飛ばす距離
    private float fallenPosition;                            //　落ちた場所
    private bool isFall;                                     //　落ちているかどうか
    public float fallenDistance;                            //　落下距離
    [SerializeField] public float takeDamageDistance = 2f;   //　どのぐらいの高さからダメージを与えるか

    // Start is called before the first frame update
    void Start()
    {
        fallenDistance = 0f;
        fallenPosition = transform.position.y;
        isFall = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(rayPosition.position, Vector3.down * rayRange, Color.blue); // レイを可視化

        if (isFall)
        {
            fallenPosition = Mathf.Max(fallenPosition, transform.position.y);   

            if (Physics.Linecast(rayPosition.position, rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("Field"))) //　着地したか判断
            {
                fallenDistance = fallenPosition - transform.position.y; //　落下距離を計算
                
                // 落下距離と与えるダメージ
                /*if (fallenDistance >= takeDamageDistance)
                {
                    HP -= (int)((fallenDistance - takeDamageDistance) * 100);

                    Debug.LogFormat("ダメージ" + (int)((fallenDistance - takeDamageDistance) * 200) + "残りHP" + HP);
                }*/
                isFall = false;
            }
        }
        else
        {
            if (!Physics.Linecast(rayPosition.position, rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask("Field", "Block")))   //　地面にレイが届いていなければ落下地点を設定
            {
                fallenPosition = transform.position.y; //　最初の落下地点を設定
                fallenDistance = 0;
                isFall = true;
            }
        }
    }


}
