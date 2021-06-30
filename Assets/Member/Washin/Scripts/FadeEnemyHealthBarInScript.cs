using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEnemyHealthBarInScript : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    private float timeToFadeIn = 4;
    private float currentTime;

    private void Start()
    {
        canvasGroup.alpha = 0;
    }
    void Update()
    {
        currentTime += Time.deltaTime / timeToFadeIn;
        canvasGroup.alpha += currentTime;
        if(canvasGroup.alpha >= 1)
        {
            canvasGroup.alpha = 1;
            this.enabled = false;
        }
    }
}
