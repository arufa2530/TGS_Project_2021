using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            StartCoroutine(GameOver());
            Debug.Log("GameOver");
        }
    }


    IEnumerator GameOver()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }

    public void GameOverTrigger()
    {
        StartCoroutine(GameOver());
    }


}
