using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasListener : MonoBehaviour
{
    [SerializeField] private PoiInput PoiInput;

    public static int x;
    public static int y;

    private void Update()
    {
        if(Input.GetKey("p") && Input.GetMouseButtonDown(0))
        {
            PoiInput.Show();

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            x = (int) worldPoint.x;
            y = (int) worldPoint.y;

            Debug.Log("X:  " + x + "   Y:   " + y);
        }
    }
}
