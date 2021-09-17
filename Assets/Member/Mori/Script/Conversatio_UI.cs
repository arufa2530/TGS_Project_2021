using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CHARNAME
{
    None = 0,
    Search,
    Operation,
    Start,
}

public class Conversatio_UI : MonoBehaviour
{
    [SerializeField] string[] charName = null;
    [SerializeField] [TextArea] string[] opeTalk = null;
    [SerializeField] [TextArea] string[] buster = null;
    [SerializeField] GameObject pRefab = null;
    [SerializeField] GameObject oPerator = null;
    [SerializeField] GameObject existence = null;
    [SerializeField] GameObject button = null;
    [SerializeField] GameObject thankYou;
    [SerializeField] GameObject sund;
    [SerializeField] Image image;
    [SerializeField] Sprite[] m_Facia;
    [SerializeField] int stop;
    [SerializeField] int _id = 0;
    [SerializeField] int _karmaValue = 0;
    //[SerializeField]AudioSource _sund;
    float is_time = 3;
    [SerializeField]float is_time2 = 4;
    float is_time3;
    [SerializeField]float is_time4 = 3;
    bool a = false;
    bool b = false;
    public bool c = false;
    public bool d = false;
    bool e = false;

    [SerializeField]CHARNAME _CHARNAME;

    [SerializeField] NewChangeScreenScript changeTemp;

    private void Awake()
    {
        switch(_CHARNAME)
        {
            case CHARNAME.Search:
                //_sund.Stop();
                //thankYou.gameObject.SetActive(false);
                sund.gameObject.SetActive(false);
                //e = true;
                break;
            case CHARNAME.None:
            case CHARNAME.Start:
                oPerator.gameObject.SetActive(false);
                break;
        }
    }

    void Start()
    {
        switch(_CHARNAME)
        {
            case CHARNAME.Search:
                image = oPerator.GetComponent<Image>();
                TalkConversatio();
                image.sprite = m_Facia[4];
                //sund.gameObject.SetActive(true);
                break;
            case CHARNAME.Operation:
                image = oPerator.GetComponent<Image>();
                TalkConversatio();
                image.sprite = m_Facia[4]; 
                break;
            case CHARNAME.None:
            case CHARNAME.Start:
                TalkConversatio();
                break;
        }
        //_sund = GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        
        if (_id == _karmaValue && !b)
        {
             a = true;
             GameObject obj = (GameObject)Instantiate(button);
             obj.transform.SetParent(existence.transform, false);
             obj.transform.localScale = new Vector3(1, 1, 1);
             b = true;
        }
        switch(_CHARNAME)
        {
            case CHARNAME.Search:
                StageOne();
                if (e) { sund.gameObject.SetActive(true); e = false; is_time4 = 3; }
                switch (_id)
                {
                    case 2:
                    case 5:
                        image.sprite = m_Facia[0];
                        break;
                    case 1:
                    case 3:
                        image.sprite = m_Facia[3];
                        break;
                    //case 0:
                    case 4:
                        image.sprite = m_Facia[4];
                        break;
                }
                break;
            case CHARNAME.Operation:
                if (_id <= 6) { StageOne(); }
                switch (_id)
                {
                    case 2:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 9:
                        image.sprite = m_Facia[0];
                        break;
                    case 1:
                    case 8:
                        image.sprite = m_Facia[1];
                        break;
                    case 11:
                        image.sprite = m_Facia[2];
                        break;
                    case 3:
                        image.sprite = m_Facia[3];
                        break;
                    //case 0:
                    case 10:
                        image.sprite = m_Facia[4];
                        break;
                }
                break;
            case CHARNAME.None:
                if (Input.GetMouseButtonDown(0))
                {
                    oPerator.gameObject.SetActive(true);
                    this.transform.root.gameObject.SetActive(false);
                }
                break;
            case CHARNAME.Start:
                if (Input.GetMouseButtonDown(0))
                {
                    if(_id >= 3) { c = true; }
                    StageOne();
                }
                break;
        }
        
    }

    void Update()
    {
        if (_id == stop && (int)is_time <= 0)
        {
            c = true;
            this.transform.root.gameObject.SetActive(false);
            switch(_CHARNAME)
            {
                case CHARNAME.Operation:
                    //thankYou.gameObject.SetActive(true);

                    changeTemp.LoadNextScene(9);
                    break;
            }
            return;
        }
        switch(_CHARNAME)
        {
            case CHARNAME.Search:
                if (_id >= 6 && _id <= 14)
                {
                    is_time2 -= Time.deltaTime;
                    if ((int)is_time2 == 0) { TalkConversatio(); is_time2 = 6; }
                }
                is_time4 -= Time.deltaTime;
                if ((int)is_time4 == 0)
                {
                    sund.gameObject.SetActive(false);

                }
                //else if((int)is_time4 <= -1) { e = true; }
                break;
            case CHARNAME.Operation:
                if (!d)
                {
                    //_sund.Stop();
                    Debug.Log("—¬‚ê‚Ä‚È‚¢‚æ");
                }
                if (d)
                {
                    sund.gameObject.SetActive(true);
                }
                break;
        }
        if (_id == stop)
        {
            is_time -= Time.deltaTime;
            a = true;
        }
        Debug.Log((int)is_time);
        
    }

    void StageOne()
    {
        if(Input.GetMouseButtonDown(0) && !a)
        {
            TalkConversatio();
        }
    }

    public void StageTwo()
    {
        Debug.Log("m’è");
        GameObject obj = (GameObject)Instantiate(pRefab);
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = buster[0];
        obj.transform.SetParent(existence.transform, false);
        obj.transform.localScale = new Vector3(1, 1, 1);
        //
        GameObject obj2 = (GameObject)Instantiate(pRefab);
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = buster[1];
        obj2.transform.SetParent(existence.transform, false);
        obj2.transform.localScale = new Vector3(1, 1, 1);
        _id++;
        a = false;
    }

    public void StageThree()
    {
        //Debug.Log("”Û’è");
        GameObject obj = (GameObject)Instantiate(pRefab);
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = buster[2];
        obj.transform.SetParent(existence.transform, false);
        obj.transform.localScale = new Vector3(1, 1, 1);
        //
        GameObject obj2 = (GameObject)Instantiate(pRefab);
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = buster[3];
        obj2.transform.SetParent(existence.transform, false);
        obj2.transform.localScale = new Vector3(1, 1, 1);
        _id++;
        a = false;
    }

    public void TalkConversatio()
    {
        GameObject obj = (GameObject)Instantiate(pRefab);
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = charName[0];
        obj.transform.SetParent(existence.transform, false);
        obj.transform.localScale = new Vector3(1, 1, 1);
        //
        GameObject obj2 = (GameObject)Instantiate(pRefab);
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = opeTalk[_id];
        obj2.transform.SetParent(existence.transform, false);
        obj2.transform.localScale = new Vector3(1, 1, 1);
        _id++;
    }

    public void TalkVo(int i)
    {
        if(i == 10)
        {
            _id = i + 1;
        }
        else
        {
            GameObject obj = (GameObject)Instantiate(pRefab);
            obj.transform.Find("Text").gameObject.GetComponent<Text>().text = charName[0];
            obj.transform.SetParent(existence.transform, false);
            obj.transform.localScale = new Vector3(1, 1, 1);
            //
            GameObject obj2 = (GameObject)Instantiate(pRefab);
            obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = opeTalk[i];
            obj2.transform.SetParent(existence.transform, false);
            obj2.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
