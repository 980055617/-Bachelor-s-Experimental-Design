using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y, 0f);
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            // 目標への方向ベクトルを計算
            Vector3 direction = (targetPosition - transform.position).normalized;

            // 移動ベクトルを速度と方向から計算
            Vector3 moveVector = direction * moveSpeed * Time.deltaTime;

            // オブジェクトを移動
            transform.Translate(moveVector);

            yield return null;
        }
        Destroy(gameObject);

    }
}
