using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{
    public void OnNextStage()
    {
        StageManager.Instance.LoadNextStage();
    }
}
