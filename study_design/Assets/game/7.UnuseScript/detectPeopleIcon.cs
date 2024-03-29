using UnityEngine;

public class detectPeople : MonoBehaviour
{
    private Camera camera;
    public LayerMask targetLayer; // 特定のレイヤー

    public manipulatecanvas manipulateCanvasA;

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

        // レイキャストで特定のレイヤーに属するオブジェクトを検出
        if (Physics.Raycast(cameraPosition, cameraDirection, out hit, Mathf.Infinity, targetLayer))
        {
            // 特定のオブジェクトを検出しました
            Debug.Log("特定のオブジェクトを検知しました: " + hit.collider.gameObject.name);
            manipulateCanvasA.Display();

            // オブジェクトが検知されたらタイマーをリセット
            detectionTimer = 0f;
            isObjectDetected = true;
        }
        else
        {
            // オブジェクトが検知されていない場合、タイマーを更新
            if (isObjectDetected)
            {
                detectionTimer += Time.deltaTime;

                // タイマーが3秒以上経過したらUndisplayを実行
                if (detectionTimer >= 2f)
                {
                    manipulateCanvasA.Undisplay();
                    isObjectDetected = false;
                }
            }
        }
    }
}





