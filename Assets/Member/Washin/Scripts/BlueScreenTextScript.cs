using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlueScreenTextScript : MonoBehaviour
{

    private TMP_Text blueScreenText;
    string currentText = "";
    string fullText = "システムに致命的なエラーが発生しました。" + Environment.NewLine + "コンプーターを再起動できません。";
    string line1;
    string line2;
    string line3;
    string line4;
    string line5;
    string line6;
    [SerializeField]
    float textScrollSpeed = 0.01f;
    //Dictionary<int, string> conversation;
    List<string> conversation = new List<string>();

    private string newline = Environment.NewLine;

    int offset = 0;

    string toSend;
    RectTransform textBox;

    public Canvas exeCanvas;


    private void Awake()
    {
        blueScreenText = GetComponent<TMP_Text>();
        textBox = GetComponent<RectTransform>();
        blueScreenText.text = fullText;
        createDictionary();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && offset == 0) 
        {
            StartCoroutine(WaitForTime());
        }
        else if (offset == 1)
        {
            this.transform.parent.parent.gameObject.SetActive(false);
        }
    }

    private void createDictionary()
    {
        Debug.Log("createDictionary Starting");

        //conversation = new Dictionary<int, string>();
        //conversation.Add(1, "もうこのパソコンは使えません。");
        //conversation.Add(2, "ウイルスの入ったメールなんか開くから...");
        //conversation.Add(3, "...え？あっまりだって？");
        //conversation.Add(4, "そうですよね！");
        //conversation.Add(5, "そういうと思ってウイルス撃退ソフトウェアを用意してるんです。");
        //conversation.Add(6, "今なら間に会います。やっつけちゃってください。");

        //conversation.Add(7, "もうこのパソコンは使えません。");
        //conversation.Add(8, "ウイルスの入ったメールなんか開くから...");
        //conversation.Add(9, "...え？あっまりだって？");
        //conversation.Add(10, "そうですよね！");
        //conversation.Add(11, "そういうと思ってウイルス撃退ソフトウェアを用意してるんです。");
        //conversation.Add(12, "今なら間に会います。やっつけちゃってください。");

        conversation.Add("1もうこのパソコンは使えません。");
        conversation.Add(newline +"2ウイルスの入ったメールなんか開くから...");
        conversation.Add(newline +"3...え？あっまりだって？");
        conversation.Add(newline +"4そうですよね！");
        conversation.Add(newline +"5そういうと思ってウイルス撃退ソフトウェアを用意してるんです。");
        conversation.Add(newline +"6今なら間に会います。やっつけちゃってください。");

        conversation.Add(newline +"7もうこのパソコンは使えません。");
        conversation.Add(newline +"8ウイルスの入ったメールなんか開くから...");
        conversation.Add(newline +"9...え？あっまりだって？");
        conversation.Add(newline +"10そうですよね！");
        conversation.Add(newline +"11そういうと思ってウイルス撃退ソフトウェアを用意してるんです。");
        conversation.Add(newline + "12今なら間に会います。やっつけちゃってください。");
    }

    IEnumerator ScrollText(string text)
    {
        Debug.Log("ScrollText Starting");
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i);
            blueScreenText.text = currentText;
            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }

    IEnumerator WaitForTime()
    {
        Debug.Log("WaitForTime Starting");
        yield return new WaitForSeconds(1);
        if (offset == 0)
        {
            Debug.Log(offset);
            StartCoroutine(ScrollText(
                conversation[0 + offset] +
                conversation[1 + offset] +
                conversation[2 + offset] +
                conversation[3 + offset] +
                conversation[4 + offset] +
                conversation[5 + offset]));
            yield return null;
        }
        if (offset > 0)
        {
            exeCanvas.gameObject.SetActive(true);
        }
        offset++;

        StopCoroutine(WaitForTime());


        //StartCoroutine(ScrollText(
        //toSend += conversation[i] + newline));
        //yield return new WaitForSeconds(0.3f);
    }

    IEnumerator AddLastLine(string text)
    {
        Debug.Log("ScrollText Starting");
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i);
            blueScreenText.text = currentText;
            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }
}
