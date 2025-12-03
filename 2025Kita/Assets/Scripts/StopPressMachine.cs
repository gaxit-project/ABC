using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StopPressMachine : MonoBehaviour
{
    public bool isStop = false;
    private Animator anim = null;
    private bool wasStop = false;

    public string animationName = "IsRunning";

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Log("アニメーションがありません");
            enabled = false;
        }
    }

    private void Update()
    {
        if (isStop && !wasStop)
        {
            anim.SetBool(animationName, false);
            StartCoroutine(DisableAnimatorAfterTransition(0.01f));
            wasStop = true;
        }
        else if (!isStop && wasStop)
        {
            anim.enabled = true;
            anim.SetBool(animationName, true);
            wasStop = false;
        }
    }

    IEnumerator DisableAnimatorAfterTransition(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.enabled = false;
    }
}