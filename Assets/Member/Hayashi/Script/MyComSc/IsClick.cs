using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsClick : MonoBehaviour
{
    bool isClick;
    public void OnClick()
    {
        if (!isClick)
        {
            isClick = true;
            StartCoroutine(MeasureTime());
        }
        else
        {
            DoubleClick();
            isClick = false;
        }

    }

    IEnumerator MeasureTime()
    {
        var times = 0f;
        while (isClick)
        {
            times += Time.deltaTime;
            if (times < 0.5f)
            {
                yield return null;
            }
            else
            {
                isClick = false;
                SingleClick();
                yield break;
            }
        }
    }

    void SingleClick()
    {
        Debug.Log("Single");
    }

    void DoubleClick()
    {
        Debug.Log("Double");
        this.GetComponent<AudioSource>().Play();
    }

}
