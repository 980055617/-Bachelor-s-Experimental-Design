using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BystanderDisplay : MonoBehaviour
{
    /*
    method of bystander display
    0: still waiting
    1: Ambient
    2: Arrow
    3: Flash
    4: Icon
    */
    private int hasReceivedInput = -1;
    private bool detectBystander = false; // detect bystander or not
    private int subjectNumber = 0; // the number of each experiment collaborator number
    private string inputText = ""; //the input from user

    private float lastDetectedTime = 0f; // last time detect bystander
    private bool startCntDetected = false; // if first time detectBystander
    private CntTimeUntilDetect cntTime;

    public Sprite iconDisplayImage; // the image used in icon display
    public GameObject arrowDisplay; // the Prefab used in arrow display
    public GameObject flashFirst; // the first flash in flash display
    public GameObject flashSecond; // the after flash in flash display

    public float timeBeforeFirstFlash = 1.0f; // first flash after detect bystander
    public float flashInterval = 2.0f ; // flash interval

    private float closestBystanderDistance = Mathf.Infinity; // the closet bystander distance
    private float dangerDistance = 1.0f; // the distance bystander shouldn't in
    private float normalDistance = 2.5f; // the distance bystander can in but should be care

    void Start()
    {
        cntTime = GetComponent<CntTimeUntilDetect>();
        StartCoroutine(WaitForKeyPress()); // Enter display method and experiment collaborator number
    }
    IEnumerator WaitForKeyPress()
    {
        // Get experiment collaborator number
        Debug.Log("被験者Noを入力してください");
        while (subjectNumber == 0)
        {
            if (Input.anyKeyDown)
            {
                foreach (char c in Input.inputString)
                {
                    // If the input is digit
                    if (char.IsDigit(c))
                    {
                        inputText += c;
                    }
                }
            }
            // Decide on input when detecting enter input
            if (Input.GetKeyDown(KeyCode.Return))
            {
                int.TryParse(inputText, out subjectNumber);
                Debug.Log("被験者No." + inputText + "で実験を開始します");
            }
            yield return null;
        }
        // Get display method
        Debug.Log("表示手法を選択してください");
        Debug.Log("0: Baseline  1: Ambient  2: Arrow  3: Flash 4: Icon");
        while (hasReceivedInput == -1)
        {
            if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                hasReceivedInput = 0;
                Debug.Log("Baseline表示法で実行する");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                hasReceivedInput = 1;
                Debug.Log("Ambient表示法で実行する");
                GameObject lightObject = new GameObject("LightObject");
                Light lightComponent = lightObject.AddComponent<Light>();

                Vector3 lightPosition = transform.position + Vector3.up * 2.0f;

                lightComponent.color = Color.green;
                lightComponent.intensity = 0f;
                lightComponent.range = 10.0f;
                lightObject.transform.position = lightPosition;

                lightObject.transform.SetParent(transform);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                hasReceivedInput = 2;
                Debug.Log("Arrow表示法で実行する");
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                hasReceivedInput = 3;
                Debug.Log("Flash表示法で実行する");
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                hasReceivedInput = 4;
                Debug.Log("Icon表示法で実行する");
                GameObject canvasObject = new GameObject("Canvas");
                Canvas canvas = canvasObject.AddComponent<Canvas>();

                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = GetComponent<Camera>();
                canvas.planeDistance = 0.5f;

                GameObject imageObject = new GameObject("Image");
                Image imageComponent = imageObject.AddComponent<Image>();
                imageComponent.sprite = iconDisplayImage;

                RectTransform imageRect = imageObject.GetComponent<RectTransform>();

                imageRect.SetParent(canvas.transform);
                imageRect.anchorMin = new Vector2(0, 1);
                imageRect.anchorMax = new Vector2(0, 1);
                imageRect.pivot = new Vector2(0, 1);
                imageRect.anchoredPosition = Vector2.zero;
                imageRect.localScale = new Vector3(0, 0, 0);
                imageRect.localRotation = Quaternion.Euler(0, 0, 0);
                imageRect.anchoredPosition3D = new Vector3(400f, -800f, 0f); // 要調整(UI位置座標)

                canvasObject.transform.SetParent(transform);
            }

            yield return null;
        }
    }


    IEnumerator FlashDisplay(GameObject obj)
    {
        yield return new WaitForSeconds(timeBeforeFirstFlash);
        BystanderDetect bystanderDetect = obj.GetComponent<BystanderDetect>();
        Vector3 Position = obj.transform.position;
        GameObject currentUI = Instantiate(flashFirst, Position, Quaternion.identity);
        currentUI.transform.SetParent(obj.transform);
        yield return new WaitForSeconds(flashInterval);
        Destroy(currentUI);
        while (bystanderDetect.checkStatus() == true)
        {
            Position = obj.transform.position;
            currentUI = Instantiate(flashSecond, Position, Quaternion.identity);
            currentUI.transform.SetParent(obj.transform);
            yield return new WaitForSeconds(flashInterval);
            Destroy(currentUI);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Bystanders = GameObject.FindGameObjectsWithTag("Bystander");
        int cnt = 0; // count bystanders num
        closestBystanderDistance = Mathf.Infinity; // reset closetDistance

        foreach (GameObject obj in Bystanders) // check each bystander
        {
            BystanderDetect bystanderDetect = obj.GetComponent<BystanderDetect>();

            // if bystander within camera vision
            if (bystanderDetect.onVision == true)
            {
                // Log first time detected bystander
                if (startCntDetected == false){
                    startCntDetected = true;
                    cntTime.CntStart();
                }


                cnt += 1;

                if (hasReceivedInput == 2) // Arrow display
                {
                    if (bystanderDetect.checkStatus() == false)
                    {
                        Vector3 Position = obj.transform.position;
                        GameObject currentUI = Instantiate(arrowDisplay, Position, Quaternion.identity);
                        currentUI.transform.SetParent(obj.transform);
                        bystanderDetect.changeStatus();
                    }

                }

                else if (hasReceivedInput == 3) // Flash display
                {
                    if (bystanderDetect.checkStatus() == false)
                    {
                        bystanderDetect.changeStatus();
                        StartCoroutine(FlashDisplay(obj));
                    }
                }

                else
                {
                    detectBystander = true;
                    lastDetectedTime = Time.time;

                    Vector3 point1WithoutY = new Vector3(transform.position.x, 0f, transform.position.z);
                    Vector3 point2WithoutY = new Vector3(obj.transform.position.x, 0f, obj.transform.position.z);
                    float distance = Vector3.Distance(point1WithoutY, point2WithoutY);

                    closestBystanderDistance = Mathf.Min(closestBystanderDistance, distance);
                }
            }
        }

        if (detectBystander == true)
        {
            if(hasReceivedInput == 1)
            {
                Transform Ambient = transform.Find("LightObject");
                Light ambientLight = Ambient.GetComponent<Light>();
                if (closestBystanderDistance <= dangerDistance)
                {
                    ambientLight.intensity = 1.5f;
                }
                else if (closestBystanderDistance <= normalDistance)
                {
                    ambientLight.intensity = 1.2f;
                }
                else
                {
                    ambientLight.intensity = 1f;
                }
            }
            if(hasReceivedInput == 4)
            {
                Transform canvasTransform = transform.Find("Canvas");
                Transform icon = canvasTransform.Find("Image");
                RectTransform iconPlace = icon.GetComponent<RectTransform>();
                if (closestBystanderDistance <= dangerDistance)
                {
                    iconPlace.localScale = new Vector3(2f,2f,2f);
                }
                else if (closestBystanderDistance <= normalDistance)
                {
                    iconPlace.localScale = new Vector3(1.5f,1.5f,1.5f);
                }
                else
                {
                    iconPlace.localScale = new Vector3(1f,1f,1f);
                }
            }
        }


        if (Time.time - lastDetectedTime > 3f && detectBystander == true)
        {
            detectBystander = false;
            closestBystanderDistance = Mathf.Infinity;
            if(hasReceivedInput == 1)
            {
                Transform Ambient = transform.Find("LightObject");
                Light ambientLight = Ambient.GetComponent<Light>();
                ambientLight.intensity = 0f;
            }

            else if(hasReceivedInput == 4)
            {
                Transform canvasTransform = transform.Find("Canvas");
                Transform icon = canvasTransform.Find("Image");
                RectTransform iconPlace = icon.GetComponent<RectTransform>();
                iconPlace.localScale = new Vector3(0,0,0);
            }
        }
    }

    // return subject number
    public int GetCollaboratorNum()
    {
        return subjectNumber;
    }

    // return the name of method (not number)
    public string GetDisplayMethod()
    {
        if (hasReceivedInput == 0)
        {
            return "Baseline";
        }
        else if (hasReceivedInput == 1)
        {
            return "Ambient";
        }
        else if (hasReceivedInput == 2)
        {
            return "Arrow";
        }
        else if (hasReceivedInput == 3)
        {
            return "Flash";
        }
        else if (hasReceivedInput == 4)
        {
            return "Icon";
        }
        else 
        {
            return "Missing";
        }
    }
}

