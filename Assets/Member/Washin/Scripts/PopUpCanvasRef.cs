using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpCanvasRef : MonoBehaviour
{
    public static GameObject canvas;

    private void Awake()
    {
        canvas = this.gameObject;
    }
}
