using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragMoveUI : MonoBehaviour
{
    Vector3 MousePos;

    private void OnMouseDown()
    {
        Debug.Log(this.transform.position);
        Vector2 mouse = RectTransformUtility.WorldToScreenPoint(Camera.main, this.GetComponent<RectTransform>().position);
        MousePos = new Vector3(mouse.x - Input.mousePosition.x, mouse.y - Input.mousePosition.y, 0f);
        Debug.Log(MousePos);
    }

    private void OnMouseUp()
    {
        MousePos = Vector3.zero;
    }

    private void OnMouseDrag()
    {
        //Cubeの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(transform.position);

        //Cubeの現在位置(マウス位置)を、pointScreenに格納
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z) + MousePos;

        //Cubeの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //Cubeの位置を、pointWorldにする
        transform.position = pointWorld;
    }
}
