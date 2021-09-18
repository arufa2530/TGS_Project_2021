using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCard : MonoBehaviour
{
    [SerializeField] SolitiaController Controller;
    [SerializeField] GameObject DrawZone;
    private void OnMouseDown()
    {
        if (DrawZone.transform.childCount < 3)
        {
            Controller.CreateCard();
        }
        else
        {
            Controller.falsecard(DrawZone.transform.GetChild(0).gameObject.GetComponent<CardState>().getkind(), DrawZone.transform.GetChild(0).gameObject.GetComponent<CardState>().getnumber());
            Destroy(DrawZone.transform.GetChild(0).gameObject);
            Controller.CreateCard();
            DrawZone.transform.GetChild(DrawZone.transform.childCount - 1).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(3.0f, 0f);
            for (int i = 0; i < DrawZone.transform.childCount - 1; i++)
            {
                DrawZone.transform.GetChild(i).gameObject.GetComponent<RectTransform>().anchoredPosition -= new Vector2(1.5f, 0f);
            }
        }

        for (int i = 0; i < DrawZone.transform.childCount; i++)
        {
            DrawZone.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sortingOrder = i;
        }

        GameObject.Find("SoundManager").GetComponent<SoundManagerSc>().PlaySeByName("Turn_over_card");
    }
}
