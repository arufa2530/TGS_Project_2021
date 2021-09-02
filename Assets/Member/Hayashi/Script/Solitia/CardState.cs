using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{
    [SerializeField] SolitiaController Controller;
    [SerializeField] int kinds;
    [SerializeField] int number;

    RectTransform MyRT;
    SpriteRenderer MySR;
    int mylayer;

    GameObject HitObject;
    int[] HitCardState = new int[2];

    public void setcard(int x, int y) { kinds = x; number = y; }

    private void Start()
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

    private void OnMouseDown()
    {
        mylayer = MySR.sortingOrder;
        mychildlayerup();
    }

    private void OnMouseUp()
    {
        Debug.Log(HitObject.tag);
        mychildlayerdown();
        if (HitObject.tag == "Card")
        {
            if (this.kinds == HitCardState[0] && this.number + 1 == HitCardState[1])
            {
                this.transform.parent = HitObject.transform;
                MyRT.anchoredPosition = new Vector3(0f, -1.5f, 0f);
                MySR.sortingOrder = HitObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    GameObject child = this.transform.GetChild(i).gameObject;
                    child.GetComponent<SpriteRenderer>().sortingOrder = MySR.sortingOrder + i + 1;
                }
            }
            else
            {
                MySR.sortingOrder = mylayer;
                MyRT.anchoredPosition = new Vector3(0f, -1.5f, 0f);
            }
        }
        else if (HitObject.tag == "Area")
        {
            MySR.sortingOrder = mylayer;
            this.transform.parent = HitObject.transform;
            MyRT.anchoredPosition = new Vector3(0f, 0f, 0f);
        }
        else
        {
            MySR.sortingOrder = mylayer;
            MyRT.anchoredPosition = new Vector3(0f, -1.5f, 0f);
        }
    }

    /*public void SetCardImage()
    {
        CardTable cardTable = Resources.Load<CardTable>("Scriotable/Card Table");
        CardKinds cardKinds = cardTable.CardKindsList[kinds];
        for (int i = 0; i < cardKinds.CardDataList.Count; i++)
        {
            card SEData = SEList.SEDataList[i];
            if (SEData.Name == this.name)
            {
                GameObject.Find("SoundManager").GetComponent<SoundManagerSc>().PlaySeByName(SEData.SESource.name);
            }
        }
    }*/
}
