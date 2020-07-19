using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasListener : MonoBehaviour
{
    [SerializeField] private PoiInput PoiInput;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICK!");
            PoiInput.Show();
        }
    }
}
