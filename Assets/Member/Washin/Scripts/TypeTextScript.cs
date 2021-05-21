using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeTextScript : MonoBehaviour
{

    string currentText = "";
    [SerializeField]
    float textScrollSpeed = 0.3f;

    IEnumerator ScrollText(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            if(i > 10)
                textScrollSpeed = 0.1f;
            yield return new WaitForSeconds(textScrollSpeed);
        }

        yield return null;
    }
}
