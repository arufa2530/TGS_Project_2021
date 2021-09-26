using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField] GameObject ipfObj;
    [SerializeField] GameObject endObj;
    //[SerializeField] Text text;
    EndConversatio_UI endConUI;
    InputField ipf;


    void Start()
    {
        ipfObj = GameObject.Find("InputField");
        ipf = ipfObj.GetComponent<InputField>();
        endObj = GameObject.Find("Content");
        endConUI = endObj.GetComponent<EndConversatio_UI>();
    }

    public void ButtonText()
    {
        if (ipf.text != "")
        {
            endConUI.loveName = ipf.text;// + "ÅF";
            endConUI.a = false;
            endConUI.talk_id++;
            //endConUI.e = true;
            //endConUI.TalkConversatio(4,10);
            //this.transform.parent.gameObject.SetActive(false);
        }
    }
}
