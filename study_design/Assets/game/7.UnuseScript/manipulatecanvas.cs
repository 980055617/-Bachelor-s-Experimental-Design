using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manipulatecanvas : MonoBehaviour
{
    // Start is called before the first frame update
    private bool display_flag = true;
    private RectTransform rectTransform;
    private float width = 100;
    private float height = 100;
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();


        rectTransform.sizeDelta = new UnityEngine.Vector2(0, 0);

        Debug.Log("Width: " + rectTransform.sizeDelta.x);    //10
        Debug.Log("Height: " + rectTransform.sizeDelta.y);   //20
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Display()
    {
        rectTransform.sizeDelta = new UnityEngine.Vector2(width, height);
    }

    public void Undisplay()
    {
        rectTransform.sizeDelta = new UnityEngine.Vector2(0, 0);
    }
}
