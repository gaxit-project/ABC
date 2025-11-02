using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private float interval = 3f;
    [SerializeField] private float startDelay = 0f; // ← 開始までの遅延時間（オプション）

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Laser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Laser()
    {
        if (startDelay > 0)
        {
            yield return new WaitForSeconds(startDelay);
        }

        bool toggle = true;

        while (true)
        {
            laser.SetActive(toggle);

            toggle = !toggle; // true/falseを反転
            yield return new WaitForSeconds(interval); // 指定秒数待機
        }
    }
}
