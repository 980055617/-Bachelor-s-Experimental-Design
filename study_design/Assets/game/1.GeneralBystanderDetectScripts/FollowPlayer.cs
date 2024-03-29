using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;

    private Vector3 startPlayerPosition;


    void Start()
    {
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
    }
}
