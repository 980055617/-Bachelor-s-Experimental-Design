using UnityEngine;

public class detectPeopleArrow : MonoBehaviour
{
    private Camera camera;
    public LayerMask targetLayer; // 特定のレイヤー

    public GameObject uiPrefab;

    private GameObject currentUI = null;

    private float detectionTimer = 0f; // 検知タイマー
    private bool isObjectDetected = false; // オブジェクトが検知されたかどうかのフラグ
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

        // Raycastで特定のレイヤーに属するオブジェクトを検出
        if (Physics.Raycast(cameraPosition, cameraDirection, out hit, Mathf.Infinity, targetLayer))
        {
            // 特定のレイヤーに属するオブジェクトを検知しました
            Debug.Log("特定のオブジェクトを検知しました: " + hit.collider.gameObject.name);

            if (currentUI == null)
            {
                currentUI = Instantiate(uiPrefab, hit.point, Quaternion.identity);
            }
            detectionTimer = 0f;
            isObjectDetected = true;
        }
        else
        {
            // 特定のオブジェクトが検出されていない場合、現在のUIを破棄
            if (currentUI != null)
            {
                detectionTimer += Time.deltaTime;

                // タイマーが3秒以上経過したらUndisplayを実行
                if (detectionTimer >= 2f)
                {
                    Destroy(currentUI);
                    currentUI = null;
                }
            }
        }
    }
}




