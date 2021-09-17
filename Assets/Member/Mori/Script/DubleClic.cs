using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DubleClic : MonoBehaviour
{
    private int timesClicked = 0;
    private float elaspedTime = 0;
    [SerializeField]
    private float timeToDoubleClick = 0.5f;
    [SerializeField]
    BannersController banners;

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
                banners.CreateBanner();
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
    //private void DoubleClicked()
    //{
    //    Debug.Log(this.name + " Double Clicked!");
    //    if (!useNew) { OldChangeScene(); return; }
    //    NewChangeScene();
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
