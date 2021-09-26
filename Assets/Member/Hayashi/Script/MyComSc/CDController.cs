using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDController : MonoBehaviour
{
    [SerializeField] GameObject Drive,RockFile;
    [SerializeField] GameObject CDPopup;
    [SerializeField] GameObject Operator;
    [SerializeField] GameObject talk;
    Conversatio_UI Conversatio;

    public CameraShake Shake;

    bool IsDrop;
    bool EndDrop;
    int ClickVal;
    //float GravDef = 0.15f;

    Rigidbody2D rig;

    Collider2D HitCollider;
    Collision2D HitCollision;

    // Start is called before the first frame update
    void Start()
    {
        IsDrop = false;
        EndDrop = false;
        ClickVal = 0;
        rig = this.GetComponent<Rigidbody2D>();
        Conversatio = talk.GetComponent<Conversatio_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(EndDrop);
        Debug.Log(HitCollider);
        if (!IsDrop)
            Follow();
 
        if (ClickVal > 2 && !IsDrop)
            IsDrop = true;
 
        if (IsDrop)
        {
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) == 0f && HitCollision != null)
            {
                EndDrop = true;
            }
        }
    }

    private void Follow()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(Drive.GetComponent<RectTransform>().anchoredPosition.x + 4f, Drive.GetComponent<RectTransform>().anchoredPosition.y + 8f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HitCollider = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HitCollider = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HitCollision = collision;
        if (HitCollision.gameObject.name == "MyComputer_2")
        {
            if (talk != null)
            {
                Conversatio.TalkVo(7);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        HitCollision = null;
    }

    private void OnMouseDown()
    {
        ClickVal++;
        if (ClickVal == 1)
        {
            Shake.ShakeY(0.5f, 1f);
        }
        else if (ClickVal == 2)
        {
            Shake.Shake(0.5f, 1.5f);
        }
    }

    private void OnMouseDrag()
    {
        if (IsDrop)
        {
            //Cubeの位置をワールド座標からスクリーン座標に変換して、objectPointに格納
            Vector3 objectPoint
                = Camera.main.WorldToScreenPoint(transform.position);

            //Cubeの現在位置(マウス位置)を、pointScreenに格納
            Vector3 pointScreen
                = new Vector3(Input.mousePosition.x,
                              Input.mousePosition.y,
                              objectPoint.z);

            //Cubeの現在位置を、スクリーン座標からワールド座標に変換して、pointWorldに格納
            Vector3 pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
            pointWorld.z = transform.position.z;

            //Cubeの位置を、pointWorldにする
            transform.position = pointWorld;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (HitCollider != null)
        {
            if (HitCollider.gameObject.name == "D:" && EndDrop)
            {
                CDPopup.SetActive(true);
                rig.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    public void CDDeload()
    {
        rig.constraints = RigidbodyConstraints2D.None;
        rig.velocity = new Vector2(0,-0.1f);
        CDPopup.SetActive(false);
    }

    public void CDLoad()
    {
        CDPopup.SetActive(false);
        //Operator.SetActive(true);
        if (talk != null)
        {
            Conversatio.TalkVo(8);
            Conversatio.TalkVo(9);
            Conversatio.d = true;
        }
        Drive.GetComponent<DriveController>().IsLoadCD = true;
        MycomSETable SEList;
        SEList = Resources.Load<MycomSETable>("Scriotable/MycomSETable");
        this.gameObject.SetActive(false);
        for (int i = 0; i < SEList.SEDataList.Count; i++)
        {
            SEData SEData = SEList.SEDataList[i];
            if (SEData.Name == this.name)
            {
                GameObject.Find("SoundManager").GetComponent<SoundManagerSc>().PlaySeByName(SEData.SESource.name);
            }
        }
        Destroy(this.gameObject);
    }
}
