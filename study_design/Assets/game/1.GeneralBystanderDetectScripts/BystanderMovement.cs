using static System.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BystanderMovement : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 startPlayerPosition;
    public GameObject objectPrefab;

    private GameObject spawnedObject;
    public float moveTime = 6f;
    private int randomNumber;
    private bool waitFlag = false;


    void Start()
    {
        randomNumber = Random.Range(0, 2);
        playerTransform = GameObject.Find("VRCamera").GetComponent<Transform>(); // チェック

        // Playerの基準座標を取得
        startPlayerPosition = playerTransform.position;
    }

    void Update()
    {
        // Playerの座標変化を取得
        Vector3 transPosition = playerTransform.position - startPlayerPosition;

        // Playerの座標変化を自分自身の変化に加える
        transform.position = transform.position + transPosition;

        // Playerの基準座標を取得
        startPlayerPosition = playerTransform.position;
        if (Input.GetKeyDown(KeyCode.F))
        {

            // 左右どちらから通り抜けるかを決定
            if (randomNumber == 0)
            {
                Debug.Log("傍観者表示を開始する、VR利用者から見て左側を通る");
            }
            else if (randomNumber == 1)
            {
                Debug.Log("傍観者表示を開始する、VR利用者から見て右側を通る");
            }


            // Playerから4m先にオブジェクトを生成
            Vector3 playerView = playerTransform.forward;
            if (playerView.x >=0)
            {
                playerView.x += Abs(playerView.y * 0.5f);
            }
            else
            {
                playerView.x -= Abs(playerView.y * 0.5f);
            }
            if (playerView.z >=0)
            {
                playerView.z += Abs(playerView.y * 0.5f);
            }
            else
            {
                playerView.z -= Abs(playerView.y * 0.5f);
            }
            playerView.y = 0f;
            Vector3 spawnPosition = playerTransform.position + playerView * 4.0f;
            spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            StartCoroutine(MoveToTargetCoroutine());
        }
    }
    IEnumerator MoveToTargetCoroutine()
    {

        // 10秒待ってからプレイヤーに向かって3秒かけて接近する、そして4秒間その場で待ってから、さらに3秒かけて通り抜ける
        yield return new WaitForSeconds(10f);
        Debug.Log("接近開始");
        float elapsedTime = 0f;

        Vector3 initialPosition = spawnedObject.transform.position;
        startPlayerPosition = playerTransform.position;

        // 利用者の左側を通る
        if (randomNumber == 0)
        {
            while (elapsedTime < moveTime)
            {
                // Playerの座標変化を取得
                Vector3 transPosition = playerTransform.position - startPlayerPosition;

                // Playerの座標変化を自分自身の変化に加える
                initialPosition = initialPosition + transPosition;

                // Playerの基準座標を取得
                startPlayerPosition = playerTransform.position;

                Vector3 targetPosition = playerTransform.position + playerTransform.right * -1f;
                
                spawnedObject.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveTime);
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= 3.0f && !waitFlag)
                {
                    yield return new WaitForSeconds(4f);
                    waitFlag = true;
                    Debug.Log("停止");
                }
                yield return null;
            }
        }
        // 利用者の右側を通る
        else if (randomNumber == 1)
        {
            while (elapsedTime < moveTime)
            {
                Vector3 targetPosition = playerTransform.position + playerTransform.right * 1f;
                spawnedObject.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveTime);
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= 3.0f && !waitFlag)
                {
                    yield return new WaitForSeconds(4f);
                    waitFlag = true;
                    Debug.Log("停止");
                }
                yield return null;
            }
        }

        // Ensure that the final position is exactly the target position
        transform.position = playerTransform.position;
        Destroy(spawnedObject);
    }
}