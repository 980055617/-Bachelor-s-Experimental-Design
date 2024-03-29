using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

using Valve.VR;


public class PositionDataLogger : MonoBehaviour
{
    private List<Vector3> positionDataBefore = new List<Vector3>();
    private List<Vector3> positionDataStart = new List<Vector3>();
    private List<Vector3> positionDataDetect = new List<Vector3>();
    private List<Vector3> positionDataAfter = new List<Vector3>();
    private int cnt = 0;

    private BystanderDisplay bystanderDisplay;

    private CntTimeUntilDetect detectTime;

    private float diffTime;
    private float cnt20Sec = 20f;
    private bool startSignal = false;

    void Start()
    {
        bystanderDisplay = GameObject.Find("VRCamera").GetComponent<BystanderDisplay>();
        detectTime = GameObject.Find("VRCamera").GetComponent<CntTimeUntilDetect>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !startSignal)
        {
            startSignal = true;
            Debug.Log(gameObject.name + "のログを取り始めます");
        }
        if (startSignal)
        {
            // 位置の記録
            if (cnt20Sec <= 0f)
            {
                positionDataAfter.Add(transform.localPosition);
            }
            else if(detectTime.isDetected)
            {
                positionDataDetect.Add(transform.localPosition);
                cnt20Sec -= Time.deltaTime;
            }
            else if (detectTime.CanStart)
            {
                cnt20Sec -= Time.deltaTime;
                positionDataStart.Add(transform.localPosition);
            }
            else
            {
                positionDataBefore.Add(transform.localPosition);
            }
        }
    }

    void OnApplicationQuit()
    {
        if (SceneManager.GetActiveScene().name != "Tutorial" && SceneManager.GetActiveScene().name != "TutorialPc" && startSignal)
        {
            // アプリケーションが終了するときにデータを書き出す
            // 気づくまでの時間
            if(gameObject.name == "VRCamera" && detectTime.CanStart)
            {
                diffTime = detectTime.ReturnDetectTime();
                string filePath1 = Path.Combine(Application.persistentDataPath, "detect_time_" + bystanderDisplay.GetCollaboratorNum() + "_" + SceneManager.GetActiveScene().name + "_" + bystanderDisplay.GetDisplayMethod() + ".txt");
                using (StreamWriter writer = new StreamWriter(filePath1))
                {
                    writer.WriteLine(diffTime.ToString());
                }
            }
            // 表示前のpositionログ
            string filePath = Path.Combine(Application.persistentDataPath, "position_data_" + bystanderDisplay.GetCollaboratorNum() + "_" + SceneManager.GetActiveScene().name + "_" + gameObject.name + "_" + bystanderDisplay.GetDisplayMethod() + "_Before.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Vector3 acceleration in positionDataBefore)
                {
                    writer.WriteLine(acceleration.x + "," + acceleration.y + "," + acceleration.z + "," + cnt * Time.fixedDeltaTime);
                    cnt++;
                }
            }
            // 表示中のpositionログ
            filePath = Path.Combine(Application.persistentDataPath, "position_data_" + bystanderDisplay.GetCollaboratorNum() + "_" + SceneManager.GetActiveScene().name + "_" + gameObject.name + "_" + bystanderDisplay.GetDisplayMethod() + "_Start.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Vector3 acceleration in positionDataStart)
                {
                    writer.WriteLine(acceleration.x + "," + acceleration.y + "," + acceleration.z + "," + cnt * Time.fixedDeltaTime);
                    cnt++;
                }
            }
            // 気づいたときのpositionログ
            filePath = Path.Combine(Application.persistentDataPath, "position_data_" + bystanderDisplay.GetCollaboratorNum() + "_" + SceneManager.GetActiveScene().name + "_" + gameObject.name + "_" + bystanderDisplay.GetDisplayMethod() + "_Detected.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Vector3 acceleration in positionDataDetect)
                {
                    writer.WriteLine(acceleration.x + "," + acceleration.y + "," + acceleration.z + "," + cnt * Time.fixedDeltaTime);
                    cnt++;
                }
            }
            // 表示後のpositionログ
            filePath = Path.Combine(Application.persistentDataPath, "position_data_" + bystanderDisplay.GetCollaboratorNum() + "_" + SceneManager.GetActiveScene().name + "_" + gameObject.name + "_" + bystanderDisplay.GetDisplayMethod() + "_Over.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Vector3 acceleration in positionDataAfter)
                {
                    writer.WriteLine(acceleration.x + "," + acceleration.y + "," + acceleration.z + "," + cnt * Time.fixedDeltaTime);
                    cnt++;
                }
            }
            if(gameObject.name == "VRCamera")
            {
                Debug.Log("データは以下の場所で保存されました: " + filePath);
                Debug.Log("今回は被験者No" + bystanderDisplay.GetCollaboratorNum() + "の手法" + bystanderDisplay.GetDisplayMethod()+"で行いました。");
            }
        }
    }
}