using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndConversatio_UI : MonoBehaviour
{
    public static string loveName { get; } = "LOVEÅF";
    [SerializeField] string[] charName = null;
    [SerializeField] [TextArea] string[] Talk = null;
    [SerializeField] [TextArea] string[] Choices = null;
    [SerializeField] GameObject pRefab = null;
    [SerializeField] GameObject existence = null;
    [SerializeField] GameObject button = null;
    int _id;
    bool a;
    bool b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        charName[4] = loveName;
    }

    private void OnMouseOver()
    {
        
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
        _id++;
    }

    public void StageTwo()
    {
        //Debug.Log("çmíË");
        GameObject obj = (GameObject)Instantiate(pRefab);
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = Choices[0];
        obj.transform.SetParent(existence.transform, false);
        obj.transform.localScale = new Vector3(1, 1, 1);
        //
        GameObject obj2 = (GameObject)Instantiate(pRefab);
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = Choices[2];
        obj2.transform.SetParent(existence.transform, false);
        obj2.transform.localScale = new Vector3(1, 1, 1);
        _id++;
        a = false;
    }

    public void StageThree()
    {
        //Debug.Log("î€íË");
        GameObject obj = (GameObject)Instantiate(pRefab);
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = Choices[1];
        obj.transform.SetParent(existence.transform, false);
        obj.transform.localScale = new Vector3(1, 1, 1);
        //
        GameObject obj2 = (GameObject)Instantiate(pRefab);
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = Choices[2];
        obj2.transform.SetParent(existence.transform, false);
        obj2.transform.localScale = new Vector3(1, 1, 1);
        _id++;
        a = false;
    }
}
