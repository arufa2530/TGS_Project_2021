using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyconClick : MonoBehaviour
{
    enum TENP
    {
        mycon,
        opeson,
        file,
        soli,
        peint,
    }
    [SerializeField]GameObject myCon;
    [SerializeField]GameObject iCon;
    [SerializeField]FileIcon icon_c;
    bool isClick;
    private int timesClicked = 0;
    private float elaspedTime = 0;
    [SerializeField]
    private float timeToDoubleClick = 0.2f;
    [SerializeField]TENP tnpu;

    private void Awake()
    {
        //myCon = GetComponent<GameObject>();
        switch(tnpu)
        {
            case TENP.mycon:
                myCon = GameObject.Find("MyComputer_2");
                myCon.SetActive(false);
                break;
            case TENP.opeson:
                myCon = GameObject.Find("CanvasOve");
                myCon.SetActive(false);
                break;
            case TENP.file:
                myCon = GameObject.Find("File");
                myCon.SetActive(false);
                break;
            case TENP.soli:
                iCon = GameObject.Find("FileIcon_a");
                icon_c = iCon.GetComponent<FileIcon>();
                break;
            case TENP.peint:
                iCon = GameObject.Find("FileIcon_a");
                icon_c = iCon.GetComponent<FileIcon>();
                break;

        }
        isClick = false;
    }
    //public void OnClick()
    //{
    //    if (!isClick) { myCon.SetActive(true); isClick = true; }
    //    else if(isClick){ myCon.SetActive(false); isClick = false; }
    //}


    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
        //banners = GetComponent<BannersController>();
    }

    void Click()
    {
        StartCoroutine(Clicked());
    }

    private IEnumerator Clicked()
    {
        yield return new WaitForEndOfFrame();
        while (elaspedTime < timeToDoubleClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //DoubleClicked();
                if(myCon != null)
                {
                    if (!isClick) { myCon.SetActive(true); isClick = true;}
                    else if (isClick) { myCon.SetActive(false); isClick = false;}
                }
                if(iCon != null)
                {
                    switch(tnpu)
                    {
                        case TENP.soli:
                            if (!isClick) { isClick = true; icon_c.a = true;}
                            else if (isClick) { isClick = false; icon_c.a = false;}
                            break;
                        case TENP.peint:
                            if (!isClick) { isClick = true; icon_c.b = true; }
                            else if (isClick) { isClick = false; icon_c.b = false; }
                            if(!icon_c.c) { icon_c.ErrorBanner(); }
                            break;

                    }
                }
                

                Debug.Log("ダブルクリックしたよ");
                timesClicked = 2;
                yield break;
            }
            elaspedTime += Time.deltaTime;
            yield return null;
        }
        if (timesClicked != 2) { Debug.Log("シングルクリックしたよ"); }
        //SingleClicked();
        elaspedTime = 0;
        timesClicked = 0;
    }
}
