using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyconClick : MonoBehaviour
{
    [SerializeField]GameObject myCon;
    bool isClick;
    private void Awake()
    {
        //myCon = GetComponent<GameObject>();
        myCon = GameObject.Find("MyComputer");
        myCon.SetActive(false);
        isClick = false;
    }
    public void OnClick()
    {
        if (!isClick) { myCon.SetActive(true); }
        else{ myCon.SetActive(false); }
    }
}
