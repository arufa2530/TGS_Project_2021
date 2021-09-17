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
    }
    [SerializeField]GameObject myCon;
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
                break;
            case TENP.opeson:
                myCon = GameObject.Find("CanvasOve");
                break;
        }
        myCon.SetActive(false);
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
                if (!isClick) { myCon.SetActive(true); isClick = true; }
                else if(isClick){ myCon.SetActive(false); isClick = false; }
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
