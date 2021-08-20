using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerController : MonoBehaviour
{
    [SerializeField] GameObject MyParent, TaskBarApp;
    [SerializeField] GameObject[] ScaleCollider = new GameObject[8];
    BoxCollider2D MyCol;
    RectTransform MyRT;
    Animator Anim;
    bool IsScaled = false, IsMinimize = false;
    Vector2 MaxScale = new Vector2(640f, 480f);
    Vector2 MaxScalePos = new Vector2(0f, 0f);
    Vector2 MyScale, MyPos;
    Vector3 MousePos;
    public Vector2 startDragPos = Vector2.zero, npos, dpos;

    enum ScaleColliderNum
    {
        Up,
        Down,
        Right,
        Left,
        Corner1,
        Corner2,
        Corner3,
        Corner4
    }

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
        MyCol.size = new Vector2(MyRT.sizeDelta.x - 2.5f, MyRT.sizeDelta.x * 0.075f - 2.5f);
        MyCol.offset = new Vector2(0f, MyRT.sizeDelta.y / 2.0f - MyRT.sizeDelta.x * 0.075f / 2.0f);

        IsScaleCollider();
    }

    private void IsScaleCollider()
    {
        bool[] direction = new bool[8];
        for (int i = 0; i < 8; i++)
        {
            ScaleCollidersCs SCSc = ScaleCollider[i].GetComponent<ScaleCollidersCs>();
            if (SCSc.isDrag)
            {
                if (i == (int)ScaleColliderNum.Up)
                    direction[(int)ScaleColliderNum.Up] = true;
                else if (i == (int)ScaleColliderNum.Down)
                    direction[(int)ScaleColliderNum.Down] = true;
                else if (i == (int)ScaleColliderNum.Right)
                    direction[(int)ScaleColliderNum.Right] = true;
                else if (i == (int)ScaleColliderNum.Left)
                    direction[(int)ScaleColliderNum.Left] = true;
                else if (i == (int)ScaleColliderNum.Corner1)
                    direction[(int)ScaleColliderNum.Corner1] = true;
                else if (i == (int)ScaleColliderNum.Corner2)
                    direction[(int)ScaleColliderNum.Corner2] = true;
                else if (i == (int)ScaleColliderNum.Corner3)
                    direction[(int)ScaleColliderNum.Corner3] = true;
                else if (i == (int)ScaleColliderNum.Corner4)
                    direction[(int)ScaleColliderNum.Corner4] = true;
            }
        }

        npos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        dpos = npos - startDragPos;

        for (int i = 0; i < 8; i++)
        {
            if (direction[i]) startDragPos = npos;
        }

        if (direction[(int)ScaleColliderNum.Up])
        {
            MyRT.sizeDelta += new Vector2(0f, dpos.y);
        }
        else if (direction[(int)ScaleColliderNum.Down])
        {
            MyRT.sizeDelta -= new Vector2(0f, dpos.y);
        }
        else if (direction[(int)ScaleColliderNum.Right])
        {
            MyRT.sizeDelta += new Vector2(dpos.x, 0f);
        }
        else if (direction[(int)ScaleColliderNum.Left])
        {
            MyRT.sizeDelta -= new Vector2(dpos.x, 0f);
        }
        else if (direction[(int)ScaleColliderNum.Corner1])
        {
            MyRT.sizeDelta -= new Vector2(dpos.x, 0f);
            MyRT.sizeDelta += new Vector2(0f, dpos.y);
        }
        else if (direction[(int)ScaleColliderNum.Corner2])
        {
            MyRT.sizeDelta += new Vector2(dpos.x, 0f);
            MyRT.sizeDelta += new Vector2(0f, dpos.y);
        }
        else if (direction[(int)ScaleColliderNum.Corner3])
        {
            MyRT.sizeDelta += new Vector2(dpos.x, 0f);
            MyRT.sizeDelta -= new Vector2(0f, dpos.y);
        }
        else if (direction[(int)ScaleColliderNum.Corner4])
        {
            MyRT.sizeDelta -= new Vector2(dpos.x, 0f);
            MyRT.sizeDelta -= new Vector2(0f, dpos.y);
        }
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

