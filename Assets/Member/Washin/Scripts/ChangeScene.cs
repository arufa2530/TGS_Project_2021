using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 2f;
    public bool isTitleScreen;

    [SerializeField]
    bool isAbleToManuallyChangeScene;

    [SerializeField] bool useOtherWait = false;
    private void Start()
    {
        if (useOtherWait) transitionTime = 100f;
    }
    // Update is called once per frame
    void Update()
    {
        //DebugToScene1
        //if (Input.GetKeyDown(KeyCode.KeypadPlus))
        if (!isAbleToManuallyChangeScene) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (!isTitleScreen)
            {
                LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }
            else LoadNextScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        
    }

    public void LoadNextScene(int _sceneId)
    {
        if (_sceneId == 100)
        {
            StartCoroutine(LoadSceneByNextID());
            return;
        }
        StartCoroutine(LoadScene(_sceneId));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator LoadSceneByNextID()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OtherWaitTime()
    {
        //useOtherWait = true;
    }
}
