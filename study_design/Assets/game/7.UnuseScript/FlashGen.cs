using UnityEngine;

public class FlashGen : MonoBehaviour
{
    public GameObject uiPrefab;
    private GameObject currentUI = null;

    private bool firstDetected = false;
    private bool afterDetected = false;
    private float detectionTimer = 0f; // 検知タイマー
    /// <summary>
    /// Rendererが任意のカメラから見えると呼び出される
    /// </summary>

    private void Update()
    {
        Debug.Log(afterDetected);
        Vector3 Position = this.transform.position;
        if (firstDetected)
        {
            detectionTimer += Time.deltaTime;
            if (detectionTimer >= 2f)
            {
            currentUI = Instantiate(uiPrefab, Position, Quaternion.identity);
            detectionTimer = 0;
            firstDetected = false;
            afterDetected = true;
            }
        }
        else if (afterDetected)
        {
            detectionTimer += Time.deltaTime;
            if (detectionTimer >= 8f)
            {
            Destroy(currentUI);
            currentUI = Instantiate(uiPrefab, Position, Quaternion.identity);
            detectionTimer = 0;
            }
        }
    }
    private void OnBecameVisible()
    {
        firstDetected = true;
    }
    /// <summary>
    /// Rendererがカメラから見えなくなると呼び出される
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(currentUI);
        afterDetected = false;
    }
}