using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityControl : MonoBehaviour
{
    [SerializeField] private float lowGravityPower = -5.0f;
    [SerializeField] private float normalGravityPower = -9.81f;
    [SerializeField] private Image image;

    private int buttonCount = 0;
    public bool normalGravity => buttonCount == 0;
    public bool lowGravity => buttonCount > 0;

    private void SetLowGravity()
    {
        Physics.gravity = new Vector3(0, lowGravityPower, 0);
        image.enabled = true;

    }

    private void SetNormalGravity()
    {
        Physics.gravity = new Vector3(0, normalGravityPower, 0);
        image.enabled = false;

    }

    private void Update()
    {
        if(normalGravity && !lowGravity)
        {
            SetNormalGravity();
        }
        else if (!normalGravity && lowGravity)
        {
            SetLowGravity();
        }
    }

    public void PressButton()
    {
        buttonCount++;
    }

    public void ReleaseButton()
    {
        buttonCount = Mathf.Max(0, buttonCount - 1);
    }
}
