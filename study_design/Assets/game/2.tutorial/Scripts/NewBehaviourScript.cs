using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ballPrefab;
    private Transform route1StartTransform;
    private Transform route1EndTransform;
    private Transform route2StartTransform;
    private Transform route2MiddleTransform;
    private Transform route2EndTransform;
    public float moveSpeed = 2.0f;

    void Start()
    {
        GameObject Route1Start = GameObject.Find("Route1Start");
        GameObject Route1End = GameObject.Find("Route1End");
        GameObject Route2Start = GameObject.Find("Route2Start");
        GameObject Route2Middle = GameObject.Find("Route2Middle");
        GameObject Route2End = GameObject.Find("Route2End");
        route1StartTransform = Route1Start.transform;
        route1EndTransform = Route1End.transform;
        route2StartTransform = Route2Start.transform;
        route2MiddleTransform = Route2Middle.transform;
        route2EndTransform = Route2End.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Fキーが押されました");
            StartCoroutine(MoveToTarget1());
            StartCoroutine(MoveToTarget2());
        }
    }
    private IEnumerator MoveToTarget1()
    {
        GameObject ball = Instantiate(ballPrefab, route1StartTransform.position, Quaternion.identity);
        float journeyLength = Vector3.Distance(route1StartTransform.position, route1EndTransform.position); // positionを取得
        float startTime = Time.time;

        while (Vector3.Distance(ball.transform.position, route1EndTransform.position) > 0.01f) // 位置の比較
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            ball.transform.position = Vector3.Lerp(route1StartTransform.position, route1EndTransform.position, journeyFraction);
            yield return null;
        }

        // 移動が完了したらボールを消滅させる
        Destroy(ball);
    }

    private IEnumerator MoveToTarget2()
    {
        GameObject ball = Instantiate(ballPrefab, route2StartTransform.position, Quaternion.identity);
        float journeyLength = Vector3.Distance(route1StartTransform.position, route2MiddleTransform.position); // positionを取得
        float startTime = Time.time;

        while (Vector3.Distance(ball.transform.position, route2MiddleTransform.position) > 0.01f) // 位置の比較
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            ball.transform.position = Vector3.Lerp(route2StartTransform.position, route2MiddleTransform.position, journeyFraction);

            yield return null;
        }

        journeyLength = Vector3.Distance(route2MiddleTransform.position, route2EndTransform.position); // positionを取得
        startTime = Time.time;

        while (Vector3.Distance(ball.transform.position, route2EndTransform.position) > 0.01f) // 位置の比較
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            ball.transform.position = Vector3.Lerp(route2MiddleTransform.position, route2EndTransform.position, journeyFraction);

            yield return null;
        }

        Destroy(ball);
    }
}
