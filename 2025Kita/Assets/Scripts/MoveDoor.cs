using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    float defaltY;  // ドアの初期位置
    float openY = 6f;   
    float speed = 2f;

    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        defaltY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen && transform.position.y < openY)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if(!isOpen && transform.position.y > defaltY)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
        }
    }
}
