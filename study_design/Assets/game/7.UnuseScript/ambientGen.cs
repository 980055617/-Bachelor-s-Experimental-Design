using UnityEngine;

public class ambientGen : MonoBehaviour
{

    public Light LightA;

    public cntBystander cntBystanderA;
    /// <summary>
    /// Rendererが任意のカメラから見えると呼び出される
    /// </summary>
    private void OnBecameVisible()
    {
        if (cntBystanderA.GetValue() == 0)
        {
            LightA.range = 30f;
        }
        cntBystanderA.IncreaseValue();
    }
    /// <summary>
    /// Rendererがカメラから見えなくなると呼び出される
    /// </summary>

    private void OnBecameInvisible()
    {
        cntBystanderA.DecreaseValue();
        if (cntBystanderA.GetValue() == 0)
        {
            LightA.range = 0f;
        }
    }
}