using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadFromScreenCover : MonoBehaviour
{


    private TMP_Text restartingText;
    private int countUp = 0;
    private int countMax = 100;
    private string PreText = "NowLoading_";
    private string EndText = "%";
    ChangeScene _changeScene;
    [SerializeField] float waitTime;
    bool firstPass = true;
    [SerializeField] int sceneToChangeTo;
    [SerializeField] bool isMenuScene;
    [SerializeField] bool startTransition;

    private void Start()
    {
        restartingText = GetComponent<TMP_Text>();
        _changeScene = GetComponentInParent<ChangeScene>();
        //_changeScene.OtherWaitTime();
    }

    private void FixedUpdate()
    {
        if (startTransition)
            StartLoadTransition();
    }

    private void StartLoadTransition()
    {
        if (firstPass)
        {
            firstPass = false;
            StartCoroutine(WaitForTime(0.2f));
        }
        if (countUp != countMax)
        {
            countUp++;
            if (countUp < countMax)
            {
                SetText();
                return;
            }
            countUp = countMax;
            SetText();
            StartCoroutine(WaitForTime(waitTime));
            _changeScene.transitionTime = 0;
            if (isMenuScene)
                _changeScene.LoadNextScene(2);
            else
                _changeScene.LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void SetText()
    {
        restartingText.text = PreText + countUp + EndText;
    }

    IEnumerator WaitForTime(float wTime)
    {
        yield return new WaitForSeconds(wTime);
    }

    public void StartNow()
    {
        startTransition = true;
    }
}

