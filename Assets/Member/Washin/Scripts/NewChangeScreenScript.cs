using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewChangeScreenScript : MonoBehaviour
{
    [SerializeField]
    bool isAbleToManuallyChangeScene;

    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] ShouldDisplaySomethingScript displaySomething;

    bool tempTimeToFade = false;

    [SerializeField]float fadeInTime;
    [SerializeField] float waitTime;

    [SerializeField] private bool shouldNotFadeToBlack;


    // Update is called once per frame
    void Update()
    {
        //DebugToScene1
        //if (Input.GetKeyDown(KeyCode.KeypadPlus))
        if (isAbleToManuallyChangeScene && Input.GetMouseButtonDown(0))
        {
            LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //if (Input.GetKeyDown(KeyCode.KeypadDivide))
        //{
        //    //tempTimeToFade = true;
        //    LoadNextScene(9);
        //}

        if (tempTimeToFade) 
        {
            if (shouldNotFadeToBlack) return;
            FadeBlackScreenIn(fadeInTime); 
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
        tempTimeToFade = true;
        yield return new WaitForSeconds(fadeInTime);
        if (displaySomething.shouldDisplaySomethingOnScreen) displaySomething.enabled = true;
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator LoadSceneByNextID()
    {
        tempTimeToFade = true;
        yield return new WaitForSeconds(fadeInTime);
        if (displaySomething.shouldDisplaySomethingOnScreen) displaySomething.enabled = true;
        yield return new WaitForSeconds(waitTime);
        LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void FadeBlackScreenIn(float timeToFade)
    {
        canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 1, timeToFade * Time.deltaTime);
    }

    public void RetryBattle()
    {
        PlayerReferences.PlayerDied();
        SceneManager.LoadScene("BulletTesting(debug)");
    }
}
