using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    private AudioManager audioManager;
    private Transform playerTransform;
    private Transform player;
    public GameObject prefabToInstantiate;
    private bool startFlag = false;
    private float sideDiff = 0.4f;
    private float sideDiff2 = 0.2f;
    private float upDownDiff = 0.3f;

    private float height;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        playerTransform = GameObject.Find("VRCamera").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // space キーが押されたかを検出
        if (Input.GetKeyDown(KeyCode.Space) && startFlag == false)
        {
            startFlag = true;
            Debug.Log("コンテンツスタート");
            height = playerTransform.position.y - 0.15f;
            sideDiff = sideDiff + player.position.x;
            sideDiff2 = sideDiff2 + player.position.x;
            // コンテンツスタート
            StartCoroutine(StartContent());
            StartCoroutine(PlayBgm());
        }
    }
    IEnumerator StartContent()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.03f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.6f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.9f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.85f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height+upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.6f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.6f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.6f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.6f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.6f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.8f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.07f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.07f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.8f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(sideDiff2);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height-upDownDiff,10f),Quaternion.identity);


        yield return new WaitForSeconds(0.6f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.2f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.2f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff2,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height-sideDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height+0.2f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height-0.2f,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff2,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.4f,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff2,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.2f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.4f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.2f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff2,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.15f,height-0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.15f,height+0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height-0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height+0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.45f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);


        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.15f,height-0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.15f,height+0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height-0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height+0.05f,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff2,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff2,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff2,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff2,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff2,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff2,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff2,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff2,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.3f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);


        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height-upDownDiff,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.55f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height+upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height-upDownDiff,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height+upDownDiff,10f),Quaternion.identity);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-sideDiff,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(4f);
        StartCoroutine(audioManager.FadeOut());

        /*
        yield return new WaitForSeconds(1.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(upDownDiff);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.35f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(-0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(sideDiff);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(sideDiff);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(upDownDiff);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(upDownDiff);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.7f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(sideDiff);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(sideDiff);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(sideDiff);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);

        yield return new WaitForSeconds(0.5f);
        newObject = Instantiate(prefabToInstantiate,new Vector3(0.5f,height,10f),Quaternion.identity);
        */
    }
    IEnumerator PlayBgm()
    {
        yield return new WaitForSeconds(4.2f);
        audioManager.PlayBGM();
        yield return null;
    }

}
