using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BystanderDetect : MonoBehaviour
{
    public bool onVision = false;

    private bool onUI = false;

    private void Start()
    {
        onVision = false;
    }
    private void OnBecameVisible()
    {
        onVision = true;
    }

    private void OnBecameInvisible()
    {
        onVision = false;
    }

    public void changeStatus()
    {
        onUI = !onUI;
    }

    public bool checkStatus()
    {
        return onUI;
    }
}
