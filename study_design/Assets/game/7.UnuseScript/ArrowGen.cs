using UnityEngine;

public class ArrowGen : MonoBehaviour
{
    public GameObject uiPrefab;
    private GameObject currentUI = null;
    /// <summary>
    /// Rendererが任意のカメラから見えると呼び出される
    /// </summary>
    private void OnBecameVisible()
    {
        Vector3 Position = this.transform.position;
        currentUI = Instantiate(uiPrefab, Position, Quaternion.identity);

    }
    /// <summary>
    /// Rendererがカメラから見えなくなると呼び出される
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(currentUI);
        currentUI = null;
    }
}