using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] SolitiaController controller;
    [SerializeField] GameObject BrushLine;

    private void Update()
    {
        if (BrushLine.transform.childCount > 0)
        {
            this.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }

    private void OnMouseDown()
    {
        controller.DestroyWindow();
    }
}
