using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleClickedChecker : MonoBehaviour
{
    [SerializeField]
    private ChangeScene _changeScene;
    [SerializeField]
    private NewChangeScreenScript _newchangeScene;
    private int timesClicked = 0;
    private float elaspedTime = 0;
    [SerializeField]
    private float timeToDoubleClick = 0.5f;
    [SerializeField]
    private int sceneIdToChangeTo;
    [SerializeField]
    public Texture2D mouseWait;
    [SerializeField]
    public bool NextSceneById;

    string scriptToUse;
    [SerializeField] bool useNew;
    bool canBeClicked = false;

    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }

    void Click()
    {
        if (!canBeClicked) return;
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
        if (!useNew) { OldChangeScene(); return; }
        NewChangeScene();
    }

    private void NewChangeScene()
    {
        if (_newchangeScene != null)
        {
            Cursor.SetCursor(mouseWait, new Vector2(mouseWait.width / 2, mouseWait.height / 2), CursorMode.Auto);
            StartCoroutine(ChangeCursorBack());
            if (NextSceneById)
            {
                _newchangeScene.LoadNextScene(100);
                return;
            }
            _newchangeScene.LoadNextScene(sceneIdToChangeTo);
        }
        else Debug.Log("No Effect Linked!");
    }

    private void OldChangeScene()
    {
        if (_changeScene != null)
        {
            Cursor.SetCursor(mouseWait, new Vector2(mouseWait.width / 2, mouseWait.height / 2), CursorMode.Auto);
            StartCoroutine(ChangeCursorBack());
            if (NextSceneById)
            {
                _changeScene.LoadNextScene(100);
                return;
            }
            _changeScene.LoadNextScene(sceneIdToChangeTo);
        }
        else Debug.Log("No Effect Linked!");
    }

    private void SingleClicked()
    {
        Debug.Log(this.name + " Single Clicked!");
    }

    IEnumerator ChangeCursorBack()
    {
        yield return new WaitForSeconds(1f);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        yield return null;
    }

    public void CanBeClicked()
    {
        canBeClicked = true;
    }


}
