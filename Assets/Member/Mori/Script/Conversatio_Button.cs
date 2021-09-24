using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversatio_Button : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] Conversatio_UI Conv_Ui;
    [SerializeField] EndConversatio_UI EndConv_Ui;
    [SerializeField] CHARNAME _CHARNAME;
    private void Awake()
    {
        switch(_CHARNAME)
        {
            case CHARNAME.Search:
                content = GameObject.Find("Content");
                Conv_Ui = content.GetComponent<Conversatio_UI>();
                break;
            case CHARNAME.Operation:
                content = GameObject.Find("Content2");
                Conv_Ui = content.GetComponent<Conversatio_UI>();
                break;
            case CHARNAME.End:
                content = GameObject.Find("Content");
                EndConv_Ui = content.GetComponent<EndConversatio_UI>();
                break;
        }
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

    public void Pos()
    {
        EndConv_Ui.StageTwo();
        this.transform.parent.gameObject.SetActive(false);
    }

    public void Neg()
    {
        EndConv_Ui.StageThree();
        this.transform.parent.gameObject.SetActive(false);
    }
}
