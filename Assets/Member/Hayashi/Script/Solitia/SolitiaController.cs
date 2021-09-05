using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolitiaController : MonoBehaviour
{
    [SerializeField] GameObject CardPrefab;
    [SerializeField] GameObject DrawZone;
    [SerializeField] GameObject Deck;
    [SerializeField] GameObject Solitia;
    [SerializeField] GameObject[] InitCards;
    CardState cardState;
    GameObject Previousobj = null;
    Vector3 objVec = new Vector3(0f, 0f, 0f);

    int drawcard = 0;
    bool[,] Allcards = new bool[2, 13];
    public void falsecard(int k, int n) { Allcards[k - 1, n - 1] = false; drawcard--; }

    private void Start()
    {
        InitCard();
    }

    void InitCard()
    {
        int flag = 0;
        System.Random rnd = new System.Random();
        while (flag < 7)
        {
            int k, n;
            CardState InitCardsState = InitCards[flag].GetComponent<CardState>();
            k = rnd.Next(1, 3);
            n = rnd.Next(1, 14);
            if (!Allcards[k - 1, n - 1])
            {
                Allcards[k - 1, n - 1] = true;
                InitCardsState.setcard(k, n);
                InitCardsState.Init();
                flag++;
                drawcard++;
            }
        }
    }

    public void CreateCard()
    {
        objVec = new Vector3((DrawZone.transform.childCount) * 1.5f, 0f, 0f);
        GameObject Createobj;
        if (Previousobj == null)
        {
            Createobj = Instantiate(CardPrefab, objVec, Quaternion.identity);
            Previousobj = Createobj;
        }
        else
        {
            Createobj = Instantiate(CardPrefab, objVec, Quaternion.identity);
        }
        Createobj.transform.parent = DrawZone.transform;
        Createobj.GetComponent<RectTransform>().anchoredPosition = objVec;
        Createobj.transform.localScale = new Vector3(1f, 1f, 1f);
        System.Random rnd = new System.Random();
        while (true)
        {
            int k, n;
            k = rnd.Next(1, 3);
            n = rnd.Next(1, 14);
            if (!Allcards[k - 1, n - 1])
            {
                Allcards[k - 1, n - 1] = true;
                Createobj.GetComponent<CardState>().setcard(k, n);
                Createobj.GetComponent<CardState>().Init();
                break;
            }
        }
        drawcard++;
    }

    public void DestroyWindow()
    {
        Destroy(Solitia.gameObject);
    }

    private void Update()
    {
        if (drawcard == 26)
        {
            Deck.SetActive(false);
        }
        else
        {
            Deck.SetActive(true);
        }
    }
}
