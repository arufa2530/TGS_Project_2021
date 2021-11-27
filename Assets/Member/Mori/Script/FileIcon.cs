using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileIcon : MonoBehaviour
{
    [SerializeField] GameObject soli;
    [SerializeField] GameObject peint;
    [SerializeField] GameObject era;
    [SerializeField] BannersController bCont;
    Erase erase;
    public bool a;
    public bool b;
    public bool c;
    public bool d = true;
    public bool e;
    void Start()
    {
        soli = GameObject.Find("Solitia");
        peint = GameObject.Find("PaintHolder");
        era = GameObject.Find("FrontPanel");
        erase = era.GetComponent<Erase>();
        erase.CanErase(!erase.canErase);
        soli.SetActive(false);
        peint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(soli != null)
        {
            if (a && d) { soli.SetActive(true); }
            else if (!a || a! && !d) { soli.SetActive(false); }
        }
        if (d) { b = false; }
        if (b && c) { peint.SetActive(true); }
        else if (!b) { peint.SetActive(false); }
    }

    public void ErrorBanner()
    {
        if (!c) bCont.CreateBanner();
    }
}
