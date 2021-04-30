using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingTextScript : MonoBehaviour
{

    string wholeText = "起動音と共にこのアイコンしか表示されず、プレイヤーは開くしかありません 。";
    string currentText = "";
    [SerializeField]
    float textScrollSpeed;


    void Start()
    {
        Debug.Log(wholeText.Length);
        StartCoroutine(ScrollText());
    }

    IEnumerator ScrollText()
    {
        for (int i = 0; i < wholeText.Length; i++)
        {
            currentText = wholeText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            if(i > 10)
                textScrollSpeed = 0.1f;
            yield return new WaitForSeconds(textScrollSpeed);
        }

        yield return null;
    }
}
