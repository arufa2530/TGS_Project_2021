using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragWindow : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    [SerializeField]
    private bool isDragging;
    Vector3 mousePos;

    void Update()
    {

        if (isDragging)
        {
            mousePos = CalcMousePositionWithOffset();
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }


    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MouseDown");
            mousePos = CalcMousePositionWithOffset();

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isDragging = true;
        }
    }

    private static Vector3 CalcMousePositionWithOffset()
    {
        Vector3 _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        return _mousePos;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        Debug.Log("MouseUp");
    }


}
