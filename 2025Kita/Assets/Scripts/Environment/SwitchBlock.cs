using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchBlock : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Collider[] col1;
    public Collider[] col2;
    public SwitchButton SwitchButton;

    public float switchTimer=3f; // 切り替え時間
    private float timer = 0f;
    public bool isOnA = true; // 時間による切り替え

    // Start is called before the first frame update
    void Start()
    {
        SetGroupActive(col1, material1, false);
        SetGroupActive(col2, material2, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SwitchButton.isOn)
        {
            timer += Time.deltaTime; // 時間をカウント

            if (timer >= switchTimer)
            {
                isOnA = !isOnA; // AとBを反転
                timer = 0f;          // タイマーをリセット
                UpdateVisuals();     // 見た目と当たり判定を更新
            }
        }
    }
    void UpdateVisuals()
    {
        SetGroupActive(col1, material1, isOnA); // 1表示
        SetGroupActive(col2, material2, !isOnA);    // 2表示
    }

    // グループごとの設定をまとめて変更する便利なメソッド
    void SetGroupActive(Collider[] colliders, Material mat, bool isActive)
    {
        // 当たり判定の切り替え
        foreach (Collider col in colliders)
        {
            if (col != null) col.enabled = isActive;
        }

        // 透明度の切り替え
        if (mat != null)
        {
            Color color = mat.color;
            color.a = isActive ? 1.0f : 0.3f; // 表示時は1.0、非表示時は0.3（半透明）
            mat.color = color;
        }
    }

}
