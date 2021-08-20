using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RestartTextScript : MonoBehaviour
{

    private TMP_Text restartingText;
    private int countUp = 0;
    private int countMax = 15360;
    private string PreText = "CPU MODE  HIGH" + Environment.NewLine + "MEMORY 640KB + ";
    private string EndText = "KB OK";
    private string underline = "_";
    private string startingText = "Windows95を起動しています...";
    [SerializeField]
    public ChangeScene _changeScene;



    private void Awake()
    {
        restartingText = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        if (countUp != countMax)
        {
            countUp += (int)Time.fixedTime * 128;
            if (countUp < countMax)
            {
                restartingText.text = PreText + countUp + EndText;
                return;
            }
            countUp = countMax;
            restartingText.text = PreText + countUp + EndText;
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(1);
        restartingText.text = underline;
        yield return new WaitForSeconds(3);
        restartingText.text = startingText + Environment.NewLine + underline;
        yield return new WaitForSeconds(3);
        _changeScene.LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
