using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 2f;

    // Update is called once per frame
    void Update()
    {
        //DebugToScene1
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            LoadNextScene(1);
        }
    }

    public void LoadNextScene(int _sceneId)
    {
        StartCoroutine(LoadScene(_sceneId));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
