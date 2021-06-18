using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerController : MonoBehaviour
{
    [SerializeField] GameObject MyParent, TaskBarApp;
    BoxCollider2D MyCol;
    RectTransform MyRT;
    Animator Anim;
    bool IsScaled = false, IsMinimize = false;
    Vector2 MaxScale = new Vector2(640f, 480f);
    Vector2 MaxScalePos = new Vector2(0f, 0f);
    Vector2 MyScale, MyPos;
    Vector3 MousePos;

    // Start is called before the first frame update
    void Start()
    {
        MyCol = this.GetComponent<BoxCollider2D>();
        MyRT = this.GetComponent<RectTransform>();
        Anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MyCol.size = new Vector2(MyRT.sizeDelta.x, MyRT.sizeDelta.x * 0.043f);
        MyCol.offset = new Vector2(0f, MyRT.sizeDelta.y / 2.0f - MyRT.sizeDelta.x * 0.043f / 2.0f);
    }

    private void OnMouseDown()
    {
        Debug.Log(this.transform.position);
        Vector2 mouse = RectTransformUtility.WorldToScreenPoint(Camera.main, MyRT.position);
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
        MyParent.transform.position = pointWorld;
    }

    public void MinimizeButton()
    {
        Anim.SetTrigger("FeedOut");
        MyPos = MyParent.transform.position;
        IsMinimize = true;
    }

    public void TaskBarMinimizeApp()
    {
        if (IsMinimize)
        {
            this.gameObject.SetActive(true);
            Anim.SetTrigger("FeedIn");
            MyParent.transform.position = MyPos;
            MyRT.position = new Vector3(-50f, -50f,this.MyRT.position.z);
            IsMinimize = false;
        }
        else
        {
            MyPos = MyParent.transform.position;
            Anim.SetTrigger("FeedOut");
            IsMinimize = true;
        }
    }

    public void ScallerButton()
    {
        if (!IsScaled)
        {
            IsScaled = true;
            MyScale = MyRT.sizeDelta;
            MyPos = MyRT.position;
            MyRT.sizeDelta = MaxScale;
            MyParent.transform.position = MaxScalePos;
        }
        else
        {
            IsScaled = false;
            MyRT.sizeDelta = MyScale;
            MyParent.transform.position = MyPos;
        }
    }

    public void CloseButton()
    {
        Destroy(TaskBarApp.gameObject);
        Destroy(MyParent.gameObject);
    }

    public void SetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}

