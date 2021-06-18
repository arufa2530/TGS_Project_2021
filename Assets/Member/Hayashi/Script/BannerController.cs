using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerController : MonoBehaviour
{
    [SerializeField] GameObject MyParent;
    BoxCollider2D MyCol;
    RectTransform MyRT;
    bool IsScaled = false, IsMinimize = false;
    Vector2 MaxScale = new Vector2(640f,480f);
    Vector2 MaxScalePos = new Vector2(0f, 0f);
    Vector2 MyScale, MyPos;

    // Start is called before the first frame update
    void Start()
    {
        MyCol = this.GetComponent<BoxCollider2D>();
        MyRT = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        MyCol.size = new Vector2(MyRT.sizeDelta.x, MyRT.sizeDelta.x * 0.043f);
        MyCol.offset = new Vector2(0f, MyRT.sizeDelta.y / 2.0f - MyRT.sizeDelta.x * 0.043f / 2.0f);
    }

    private void OnMouseDrag()
    {
        //Cube�̈ʒu�����[���h���W����X�N���[�����W�ɕϊ����āAobjectPoint�Ɋi�[
        Vector3 objectPoint
            = Camera.main.WorldToScreenPoint(transform.position);

        //Cube�̌��݈ʒu(�}�E�X�ʒu)���ApointScreen�Ɋi�[
        Vector3 pointScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y - this.GetComponent<BoxCollider2D>().offset.y,
                          objectPoint.z);

        //Cube�̌��݈ʒu���A�X�N���[�����W���烏�[���h���W�ɕϊ����āApointWorld�Ɋi�[
        Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        pointWorld.z = transform.position.z;

        //Cube�̈ʒu���ApointWorld�ɂ���
        transform.position = pointWorld;
    }

    public void MinimizeButton()
    {
        IsMinimize = true;
        this.gameObject.SetActive(false);
    }

    public void TaskBarMinimizeApp()
    {
        if (IsMinimize)
        {
            IsMinimize = false;
            this.gameObject.SetActive(true);
        }
        else
        {
            IsMinimize = true;
            this.gameObject.SetActive(false);
        }
    }

    public void ScallerButton()
    {
        if (!IsScaled)
        {
            IsScaled = true;
            MyScale = MyRT.sizeDelta;
            MyPos = MyRT.position;
            Debug.Log(MyPos);
            MyRT.sizeDelta = MaxScale;
            MyRT.position = MaxScalePos;
        }
        else
        {
            IsScaled = false;
            MyRT.sizeDelta = MyScale;
            MyRT.position = MyPos;
        }
    }

    public void CloseButton()
    {
        Destroy(MyParent.gameObject);
    }
}
