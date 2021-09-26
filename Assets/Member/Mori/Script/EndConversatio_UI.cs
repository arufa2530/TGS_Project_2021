using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndConversatio_UI : MonoBehaviour
{
    public string loveName { get; set; } = "LOVE：";
    [SerializeField] string[] charName = null;
    [SerializeField] [TextArea] string[] Talk = null;
    [SerializeField] [TextArea] string[] Choices = null;
    [SerializeField] GameObject pRefab = null;
    [SerializeField] GameObject existence = null;
    [SerializeField] GameObject button = null;
    [SerializeField] VideoPlayer vPlay;
    [SerializeField] NewChangeScreenScript changeTemp;
    [SerializeField] int[] _karmaValue;
    GameObject nameInput;
    public int talk_id;
    int name_id;
    [SerializeField] float input_time;
    public bool a = false;
    bool b = false;
    bool c = false;
    bool d = false;
    public bool e = false;
    // Start is called before the first frame update
    void Start()
    {
        TalkConversatio(1,talk_id);
        nameInput = GameObject.Find("character_name_select_4");
        nameInput.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        charName[4] = loveName;
        if (d)
        {
            input_time -= Time.deltaTime;
        }
        if ((int)input_time == 0)
        {
            nameInput.gameObject.SetActive(true);
            d = false;
        }
        if (!a && talk_id == 11)
        {
            TalkConversatio_or_Name(name_id, talk_id);
        }
        if (talk_id >= 11)
        {
            nameInput.gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if (talk_id == _karmaValue[0] && !b)
        {
            a = true;
            GameObject obj = (GameObject)Instantiate(button);
            obj.transform.SetParent(existence.transform, false);
            obj.transform.localScale = new Vector3(1, 1, 1);
            b = true;
        }
        if (talk_id == _karmaValue[1] && !c)
        {
            //nameInput.gameObject.SetActive(true);
            a = true;
            c = true;
            d = true;
        }
        if (Input.GetMouseButtonDown(0) && !a)
        {
            if (talk_id >= 12) 
            {
                vPlay.Play();
                this.gameObject.transform.root.gameObject.SetActive(false);
                return; 
            }
            TalkConversatio(name_id, talk_id); 

        }
        switch (talk_id)
        {
            case 2:
            case 5:
            case 7:
                name_id = 2;
                break;
            case 3:
            case 4:
            case 6:
            case 8:
            case 9:
                name_id = 1;
                break;
            case 10:
            case 11:
                name_id = 4;
                break;
                
        }
    }

    public void TalkConversatio(int name_id, int id)
    {
        GameObject obj = (GameObject)Instantiate(pRefab);
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = charName[name_id];
        obj.transform.SetParent(existence.transform, false);
        obj.transform.localScale = new Vector3(1, 1, 1);
        //
        GameObject obj2 = (GameObject)Instantiate(pRefab);
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = Talk[id];
        obj2.transform.SetParent(existence.transform, false);
        obj2.transform.localScale = new Vector3(1, 1, 1);
        talk_id++;
    }
    public void TalkConversatio_or_Name(int name_id, int id)
    {
        GameObject obj = (GameObject)Instantiate(pRefab);
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = charName[name_id] + "：";
        obj.transform.SetParent(existence.transform, false);
        obj.transform.localScale = new Vector3(1, 1, 1);
        //
        GameObject obj2 = (GameObject)Instantiate(pRefab);
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = "『" + charName[4] + "』\n" + Talk[id];
        obj2.transform.SetParent(existence.transform, false);
        obj2.transform.localScale = new Vector3(1, 1, 1);
        talk_id++;
        //e = false;
    }

    public void StageTwo()
    {
        //Debug.Log("肯定");
        GameObject obj = (GameObject)Instantiate(pRefab);
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = Choices[0];
        obj.transform.SetParent(existence.transform, false);
        obj.transform.localScale = new Vector3(1, 1, 1);
        //
        GameObject obj2 = (GameObject)Instantiate(pRefab);
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = Choices[2];
        obj2.transform.SetParent(existence.transform, false);
        obj2.transform.localScale = new Vector3(1, 1, 1);
        talk_id++;
        a = false;
    }

    public void StageThree()
    {
        //Debug.Log("否定");
        GameObject obj = (GameObject)Instantiate(pRefab);
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = Choices[1];
        obj.transform.SetParent(existence.transform, false);
        obj.transform.localScale = new Vector3(1, 1, 1);
        //
        GameObject obj2 = (GameObject)Instantiate(pRefab);
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = Choices[2];
        obj2.transform.SetParent(existence.transform, false);
        obj2.transform.localScale = new Vector3(1, 1, 1);
        talk_id++;
        a = false;
    }

    //public void LastPlay(VideoPlayer vp)
    //{
    //    vPlay.Stop();
    //    //changeTemp.LoadNextScene(0);
    //}
}
