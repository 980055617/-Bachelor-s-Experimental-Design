using UnityEngine;

public class IconGen : MonoBehaviour
{
    public manipulatecanvas manipulateCanvasA;
    public cntBystander cntBystanderA;
    /// <summary>
    /// Rendererが任意のカメラから見えると呼び出される
    /// </summary>
    private void OnBecameVisible()
    {
        if (cntBystanderA.GetValue() == 0)
        {
            manipulateCanvasA.Display();
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
            manipulateCanvasA.Undisplay();
        }
    }

    public void changeInfo(manipulatecanvas manipulatecanvasComponent, cntBystander cntBystanderComponent)
    {
        manipulateCanvasA = manipulatecanvasComponent;
        cntBystanderA = cntBystanderComponent;
    }
}