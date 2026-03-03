using UnityEngine;
using Cinemachine;

public class FarCamera : MonoBehaviour
{
    [Header("Cinemachine Cameras")]
    public CinemachineVirtualCamera normalCamera;
    public CinemachineVirtualCamera farCamera;

    [Header("Input")]
    public string farCameraButtonName = "FarCamera";

    private bool isFarView = false;

    void Start()
    {
        // ‰Šúó‘ÔF’ÊíƒJƒƒ‰
        SetFarView(false);
    }

    void Update()
    {
        bool wantFar = Input.GetButton(farCameraButtonName);

        // ó‘Ô‚ª•Ï‚í‚Á‚½‚¾‚¯Ø‚è‘Ö‚¦‚é
        if (wantFar != isFarView)
        {
            SetFarView(wantFar);
        }
    }

    //˜ëáÕƒJƒƒ‰‚Ö‚ÌØ‚è‘Ö‚¦ˆ—
    private void SetFarView(bool far)
    {
        if (normalCamera != null)
            normalCamera.Priority = far ? 5 : 15;

        if (farCamera != null)
            farCamera.Priority = far ? 15 : 5;

        isFarView = far;
    }
}
