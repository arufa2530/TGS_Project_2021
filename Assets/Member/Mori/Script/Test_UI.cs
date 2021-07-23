using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_UI : MonoBehaviour
{
    [SerializeField] [TextArea] string[] abc;
    [SerializeField] GameObject[] pref;
    [SerializeField] GameObject ga;

    void Start()
    {
        GameObject obj = (GameObject)pref[0];
        obj.transform.Find("Text").gameObject.GetComponent<Text>().text = abc[0];
        //
        GameObject obj2 = (GameObject)pref[1];
        obj2.transform.Find("Text").gameObject.GetComponent<Text>().text = abc[1];
    }

}
