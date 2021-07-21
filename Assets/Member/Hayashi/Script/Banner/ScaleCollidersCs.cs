using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCollidersCs : MonoBehaviour
{
    public bool isDrag = false;
    [SerializeField] GameObject bc;

    private void Update()
    {
        if (this.name == "Up" || this.name == "Down")
        {
            this.GetComponent<BoxCollider2D>().size = new Vector2(bc.GetComponent<RectTransform>().sizeDelta.x - 5f, 5f);
        }
        else if(this.name == "Right" || this.name == "Left")
        {
            this.GetComponent<BoxCollider2D>().size = new Vector2(5f, bc.GetComponent<RectTransform>().sizeDelta.y - 5f);
        }
    }

    private void OnMouseDown()
    {
        bc.GetComponent<BannerController>().startDragPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    private void OnMouseDrag()
    {
        isDrag = true;
    }

    private void OnMouseUp()
    {
        isDrag = false;
    }
}
