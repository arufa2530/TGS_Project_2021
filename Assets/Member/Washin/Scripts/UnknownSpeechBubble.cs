using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownSpeechBubble : MonoBehaviour
{
    [SerializeField] GameObject fadeonSpawn;
    private float elaspedTime = 0;
    [SerializeField]
    private float timeToDoubleClick = 0.5f;
    private void OnMouseDown()
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
                DoubleClicked();
                yield break;
            }
            elaspedTime += Time.deltaTime;
            yield return null;
        }
        elaspedTime = 0;
    }

    private void DoubleClicked()
    {
        Instantiate(fadeonSpawn);
    }
}
