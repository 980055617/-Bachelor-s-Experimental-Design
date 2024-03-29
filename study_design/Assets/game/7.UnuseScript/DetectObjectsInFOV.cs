using UnityEngine;

public class DetectObjectsInFOV : MonoBehaviour
{
    private Camera camera;
    public LayerMask targetLayer; // 特定のレイヤー
    private float fieldOfView = 60f; // カメラの画角

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        // カメラの位置を取得
        Vector3 cameraPosition = camera.transform.position;

        // カメラの前方ベクトルを取得
        Vector3 cameraForward = camera.transform.forward;

        // カメラのFOVを考慮してRayの方向を計算
        float halfFOV = fieldOfView * 0.5f;
        Vector3 rayDirection = Quaternion.AngleAxis(-halfFOV, camera.transform.right) * cameraForward;

        RaycastHit hit;
        // Raycastで特定のレイヤーに属するオブジェクトを検出
        if (Physics.Raycast(cameraPosition, rayDirection, out hit, Mathf.Infinity, targetLayer))
        {
            // 検出したオブジェクトの情報をログに表示
            Debug.Log("特定のオブジェクトを検出しました: " + hit.collider.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        camera = GetComponent<Camera>();
        Vector3 cameraPosition = camera.transform.position;
        // カメラの前方ベクトルを取得
        Vector3 cameraForward = camera.transform.forward;

        // カメラのFOVを考慮してRayの方向を計算
        float halfFOV = fieldOfView * 0.5f;
        Vector3 rayDirection = Quaternion.AngleAxis(-halfFOV, camera.transform.right) * cameraForward;

        Vector3 arrowEnd = cameraPosition + rayDirection * 5f;

        // Gizmosを使用して矢印を描画
        Gizmos.color = Color.red; // 矢印の色を設定
        Gizmos.DrawLine(cameraPosition, arrowEnd); // 矢印を描画
    }
}