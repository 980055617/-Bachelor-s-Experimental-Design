using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CntTimeUntilDetect : MonoBehaviour
{
    private float displayMethodTime = 0f; // the first time display method display
    private float detectedMethodTime = 0f; // the collaborator detected the display method
    public bool isDetected = false; // check if the bottom is pushed
    private SteamVR_Action_Boolean Iui = SteamVR_Actions.default_InteractUI;

    public bool CanStart = false;
    private float diffTime = 0f;

    void Update()
    {
        if (isDetected == false && CanStart == true && Iui.GetState(SteamVR_Input_Sources.LeftHand))
        {
            isDetected = true;
            detectedMethodTime = Time.time;
            Debug.Log("被験者が表示に気づきました。");
        }
    }

    public void CntStart()
    {

        displayMethodTime = Time.time;
        CanStart = true;
        Debug.Log("表示開始時間を記録しました。");

    }
    public float ReturnDetectTime()
    {
        if (displayMethodTime == 0f || detectedMethodTime == 0f)
        {
            Debug.Log("表示時間:" + displayMethodTime + " 検知時間:" + detectedMethodTime + " でエラーがあります。");
        }
        else{
            diffTime = detectedMethodTime - displayMethodTime;
        }
        return diffTime;
    }
}
