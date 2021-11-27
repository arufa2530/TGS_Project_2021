using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCon : MonoBehaviour
{
    [SerializeField] GameObject talk_UI;
    [SerializeField] GameObject content;
    [SerializeField] GameObject content2;
    [SerializeField] GameObject ope;
    [SerializeField] GameObject sund;
    Conversatio_UI conversatio;
    Conversatio_UI conversatio2;

    private void Awake()
    {
        conversatio = content.GetComponent<Conversatio_UI>();
        conversatio2 = content.GetComponent<Conversatio_UI>();
        //conversatio[1] = content[1].GetComponent<Conversatio_UI>();
        talk_UI.gameObject.SetActive(false);
        //talk_UI[1].gameObject.SetActive(false);
        ope.gameObject.SetActive(false);
        if (sund != null) { sund.gameObject.SetActive(false); }
        //ope[1].gameObject.SetActive(false);
    }

    private void Update()
    {
        if(conversatio.c)
        {
            talk_UI.gameObject.SetActive(true);
            ope.gameObject.SetActive(true);
        }
        if(conversatio2.d)
        {
            if (sund != null) { sund.gameObject.SetActive(true); }
            Debug.Log("—¬‚ê‚Ä‚é‚æ");
        }
        Debug.Log("—¬‚ê");
    }
}
