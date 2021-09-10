using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{
    int kinds;
    int number;

    RectTransform MyRT;
    SpriteRenderer MySR;
    int mylayer;
    Vector3 myPos;

    GameObject HitObject;
    int[] HitCardState = new int[2];

    public void setcard(int x, int y) { kinds = x; number = y; }
    public int getkind() { return kinds; }
    public int getnumber() { return number; }

    public void Init()
    {
        MyRT = this.GetComponent<RectTransform>();
        MySR = this.GetComponent<SpriteRenderer>();
        CardTable cardTable = Resources.Load<CardTable>("Scriotable/Card Table");
        if (cardTable.CardKindsList[kinds - 1] != null)
            this.GetComponent<SpriteRenderer>().sprite = cardTable.CardKindsList[kinds - 1].CardDataList[number].Image;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HitObject = collision.gameObject;
        CardState hitstate = collision.gameObject.GetComponent<CardState>();
        if (hitstate != null)
        {
            HitCardState[0] = hitstate.kinds;
            HitCardState[1] = hitstate.number;
        }
    }

    public void mychildlayerup()
    {
        MySR.sortingOrder += 999;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject child = this.transform.GetChild(i).gameObject;
            child.GetComponent<CardState>().mychildlayerup();
            child.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void mychildlayerdown()
    {
        MySR.sortingOrder -= 999;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject child = this.transform.GetChild(i).gameObject;
            child.GetComponent<CardState>().mychildlayerdown();
            child.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void childlayer(int layer)
    {
        MySR.sortingOrder = layer + 1;
        if (this.transform.childCount > 0)
        {
            GameObject child = this.transform.GetChild(0).gameObject;
            child.GetComponent<CardState>().childlayer(MySR.sortingOrder);
        }
    }

    private void OnMouseDown()
    {
        mylayer = MySR.sortingOrder;
        myPos = MyRT.anchoredPosition;
        mychildlayerup();
    }

    private void OnMouseUp()
    {
        mychildlayerdown();
        if (HitObject == null)
        {
            MySR.sortingOrder = mylayer;
            MyRT.anchoredPosition = myPos;
        }
        else if (HitObject.tag == "Card")
        {
            if (this.kinds != HitCardState[0] && this.number + 1 == HitCardState[1])
            {
                this.transform.parent = HitObject.transform;
                MyRT.anchoredPosition = new Vector3(0f, -1.5f, 0f);
                childlayer(HitObject.GetComponent<SpriteRenderer>().sortingOrder);
            }
            else
            {
                MySR.sortingOrder = mylayer;
                MyRT.anchoredPosition = myPos;
            }
        }
        else if (HitObject.tag == "Area" && this.number == 13)
        {
            MySR.sortingOrder = mylayer;
            this.transform.parent = HitObject.transform;
            MyRT.anchoredPosition = new Vector3(0f, 0f, 0f);
        }
        else if (HitObject.tag == "Complete")
        {
            if (this.kinds == HitObject.GetComponent<CompleteZoneState>().kinds && this.number == HitObject.transform.childCount + 1)
            {
                MySR.sortingOrder = HitObject.transform.childCount + 1;
                this.transform.parent = HitObject.transform;
                MyRT.anchoredPosition = new Vector3(0f, 0f, 0f);
                this.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                MySR.sortingOrder = mylayer;
                MyRT.anchoredPosition = myPos;
            }
        }
        else
        {
            MySR.sortingOrder = mylayer;
            MyRT.anchoredPosition = myPos;
        }
    }

    private void Update()
    {
        if (this.transform.childCount > 0)
        {
            this.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 5.15f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(9f, 2f);
        }
        else
        {
            this.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
            this.GetComponent<BoxCollider2D>().size = new Vector2(9f, 12.3f);
        }
    }
}
