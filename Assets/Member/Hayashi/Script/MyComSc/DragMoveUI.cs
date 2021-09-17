using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragMoveUI : MonoBehaviour
{
    Vector3 mousePos;

    private void OnMouseDown()
    {
        // Objectの中心座標とマウスの座標との差分を計算、MousePosに格納
        Vector2 obj = RectTransformUtility.WorldToScreenPoint(Camera.main, this.GetComponent<RectTransform>().position);
        mousePos = new Vector3(obj.x - Input.mousePosition.x, obj.y - Input.mousePosition.y, 0f);;
    }

    private void OnMouseUp()
    {
        mousePos = Vector3.zero;
    }

    private void OnMouseDrag()
    {
        //objectの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(transform.position);

        //マウスの現在位置をpointScreenに格納
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPoint.z) + mousePos;

        //pointScreenを、スクリーン座標からワールド座標に変換して、pointWorldに格納
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //Objectの位置を、pointWorldにする
        transform.position = pointWorld;
    }
}
