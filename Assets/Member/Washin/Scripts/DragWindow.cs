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
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //rb.velocity = Vector2.zero;
        if (isDragging)
        {
            mousePos = CalcMousePositionWithOffset();
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            rb.MovePosition(new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0));
        }
    }


    public void OnMouseDown()
    {
        if (PlayerReferences.playerMovement.GetCurrentPlayerMode() == PlayerMovement.PlayerModes.InspectMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("MouseDown");
                rb.mass = 0.0001f;
                rb.bodyType = RigidbodyType2D.Dynamic;
                mousePos = CalcMousePositionWithOffset();

                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;

                isDragging = true;
            }
        }
    }

    public void OnMouseUp()
    {
        if (PlayerReferences.playerMovement.GetCurrentPlayerMode() == PlayerMovement.PlayerModes.InspectMode)
        {
            isDragging = false;
            Debug.Log("MouseUp");
            rb.mass = 5000f;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private static Vector3 CalcMousePositionWithOffset()
    {
        Vector3 _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        return _mousePos;
    }



}
