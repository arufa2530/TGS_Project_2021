using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversatio_Button : MonoBehaviour
{
    [SerializeField]GameObject content;
    [SerializeField] Conversatio_UI Conv_Ui;
    [SerializeField] CHARNAME _CHARNAME;
    private void Awake()
    {
        switch(_CHARNAME)
        {
            case CHARNAME.Search:
                content = GameObject.Find("Content");
                break;
            case CHARNAME.Operation:
                content = GameObject.Find("Content2");
                break;
        }
        Conv_Ui = content.GetComponent<Conversatio_UI>();
    }
    
    public void Positive()
    {
        Conv_Ui.StageTwo();
        this.transform.parent.gameObject.SetActive(false);
    }

    public void Negation()
    {
        Conv_Ui.StageThree();
        this.transform.parent.gameObject.SetActive(false);
    }
}
