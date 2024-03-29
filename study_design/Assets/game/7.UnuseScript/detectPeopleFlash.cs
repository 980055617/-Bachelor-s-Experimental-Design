using UnityEngine;

public class detectPeopleFlash : MonoBehaviour
{
    private Camera camera;
    public LayerMask targetLayer; // 特定のレイヤー

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        // カメラの位置と方向を取得
        Vector3 cameraPosition = camera.transform.position;
        Vector3 cameraDirection = camera.transform.forward;

        RaycastHit hit;

        Debug.Log(cameraDirection);
        // Raycastで特定のレイヤーに属するオブジェクトを検出
        if (Physics.Raycast(cameraPosition, cameraDirection, out hit, Mathf.Infinity, targetLayer))
        {
            // 特定のレイヤーに属するオブジェクトを検知しました
            Debug.Log("特定のオブジェクトを検知しました: " + hit.collider.gameObject.name);
        }

    }
}




