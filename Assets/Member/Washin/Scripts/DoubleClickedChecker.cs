using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleClickedChecker : MonoBehaviour
{
    [SerializeField]
    private ChangeScene _changeScene;
    private int timesClicked = 0;
    private float elaspedTime = 0;
    [SerializeField]
    private float timeToDoubleClick = 0.5f;
    [SerializeField]
    private int sceneIdToChangeTo;

    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }

    void Click()
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
                timesClicked = 2;
                yield break;
            }
            elaspedTime += Time.deltaTime;
            yield return null;
        }
        if (timesClicked != 2)
            SingleClicked();
        elaspedTime = 0;
        timesClicked = 0;
    }

    private void DoubleClicked()
    {
        Debug.Log(this.name + " Double Clicked!");
        if (_changeScene != null)
            _changeScene.LoadNextScene(sceneIdToChangeTo);
        else Debug.Log("No Effect Linked!");
    }

    private void SingleClicked()
    {
        Debug.Log(this.name + " Single Clicked!");
    }

}
