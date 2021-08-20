using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 2f;

    private void Start()
    {
        PlayerReferences.theGameIsOver = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug
        //if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        //{
        //    StartCoroutine(GameOver());
        //    Debug.Log("GameOver");
        //}
    }


    IEnumerator GameOver()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }

    //public void GameOverTrigger()
    //{
    //    SceneManager.LoadScene(1);
    //    Destroy(PlayerReferences.theHealthUI.transform.parent.gameObject);
    //    Destroy(PlayerReferences.thePlayer.gameObject);
    //    StartCoroutine(GameOver());
    //}


    public void GameOverTrigger()
    {
        SceneManager.LoadScene("S_Test");
        Destroy(PlayerReferences.theHealthUI.transform.parent.gameObject);
        Destroy(PlayerReferences.thePlayer.gameObject);
        StartCoroutine(GameOver());
    }

    //public void ReturnToDesktop()
    //{
    //    SceneManager.LoadScene("DesktopScene");
    //}

    public void ReturnToDesktop()
    {
        SceneManager.LoadScene("S_Test");
    }
}
