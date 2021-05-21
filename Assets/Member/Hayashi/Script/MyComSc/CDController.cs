using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDController : MonoBehaviour
{
    [SerializeField] GameObject Drive;
    [SerializeField] GameObject CDPopup;
    [SerializeField] GameObject Operator;

    bool IsDrop;
    bool EndDrop;
    int ClickVal;
    float GravDef = 0.15f;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDrop)
            Follow();
 
        if (ClickVal > 2 && !IsDrop)
            IsDrop = true;
 
        if (IsDrop)
        {
            if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) < 0.1f && HitCollision.gameObject.name == "MyComputer")
            {
                EndDrop = true;
            }
        }
    }

    private void Follow()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(Drive.GetComponent<RectTransform>().anchoredPosition.x + 11f, Drive.GetComponent<RectTransform>().anchoredPosition.y + 24f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HitCollider = collision;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HitCollision = collision;
    }

    private void OnMouseDown()
    {
        ClickVal++;
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
        if (HitCollider.gameObject.name == "D:" && EndDrop)
        {
            CDPopup.SetActive(true);
            rig.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void CDDeload()
    {
        CDPopup.SetActive(false);
        EndDrop = false;
        rig.constraints = RigidbodyConstraints2D.None;
    }

    public void CDLoad()
    {
        CDPopup.SetActive(false);
        Operator.SetActive(true);
        Drive.GetComponent<DriveController>().IsLoadCD = true;
        Drive.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
    }
}
