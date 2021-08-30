using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] SolitiaController controller;
    private void OnMouseDown()
    {
        controller.DestroyWindow();
    }
}
