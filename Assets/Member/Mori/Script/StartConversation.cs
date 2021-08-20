using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartConversation : MonoBehaviour
{
    public enum TALK
    {
        talk_1,
        talk_2,
    }
    [SerializeField] GameObject talk_UI;
    //[SerializeField] GameObject talk_UI2;
    [SerializeField] GameObject ope;
    //[SerializeField] GameObject ope2;
    [SerializeField] float is_Time = 10;
    [SerializeField] TALK tAlk;

    private void Start()
    {
        switch(tAlk)
        {
            case TALK.talk_1:
                //talk_UI = GameObject.Find("Talk_illust_Banner");
                talk_UI.SetActive(false);
                ope.SetActive(false);
                break;
            case TALK.talk_2:
                //talk_UI2 = GameObject.Find("Talk_illust_Banner2");
                //talk_UI2.SetActive(false);
                //ope2.SetActive(false);
                break;
        }
    }

    private void Update()
    {
        if((int)is_Time >= 0)
        {
            is_Time -= Time.deltaTime;
        }
        //is_Time -= Time.deltaTime;
        if((int)is_Time <= 0)
        {
            talk_UI.SetActive(true);
            ope.SetActive(true);
            Debug.Log("");
        }
        Debug.Log((int)is_Time);
    }
}
