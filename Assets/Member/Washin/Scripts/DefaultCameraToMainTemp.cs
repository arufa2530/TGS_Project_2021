using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCameraToMainTemp : MonoBehaviour
{

    Canvas canvas;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }
}
