using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    public bool normalGravity = true;
    public bool lowGravity = false;

    public void SetLowGravity()
    {
        Physics.gravity = new Vector3(0, -2f, 0);
        lowGravity = true;
        normalGravity = false;
    }

    public void SetNormalGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        normalGravity = true;
        lowGravity = false;
    }

}
