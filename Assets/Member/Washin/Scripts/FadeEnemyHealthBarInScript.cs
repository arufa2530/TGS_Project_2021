using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEnemyHealthBarInScript : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    private float timeToFadeInHealthBar = 1;
    private float timeToFadeOutHealthBar = 1;
    private float timeToFadeInRedBar = 2;
    [SerializeField] private float currentTime = 0;

    [SerializeField] RectTransform healthBarUI;
    Vector3 higherPos;
    Vector3 lowerPos;
    private Vector3 lerpingPos;
    [SerializeField] private bool step1Done = false;
    bool slideInDone = false;
    private bool step2Done = false;
    public bool shouldSlideOut = false;
    [SerializeField] private bool barIsFilled = false;
    int yOffset = 75;

    [SerializeField]public Slider redBar;

    private void Start()
    {
        //canvasGroup.alpha = 0;
        healthBarUI.localPosition = new Vector3(0, 275, -91);
        higherPos = healthBarUI.localPosition;
        lowerPos = new Vector3(0, 200, -91);
        //StartCoroutine(HealthBarSlideIn());
        redBar.value = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) { shouldSlideOut = true; currentTime = 0; }
        if (!slideInDone)
            StartCoroutine(HealthBarSlideIn());
        else if(!barIsFilled)
            FullHealthBarToFull();
        if (shouldSlideOut)
            StartCoroutine(HealthBarSlideOut());
    }

    private void FullHealthBarToFull()
    {
        currentTime += Time.deltaTime / timeToFadeInRedBar;
        redBar.value = Mathf.Lerp(1, redBar.maxValue, currentTime);
        if (redBar.value < redBar.maxValue)
        {
            return;
        }
        redBar.value = redBar.maxValue;
        barIsFilled = true;
        currentTime = 0;
    }

    private IEnumerator HealthBarSlideIn()
    {
        if (!step1Done)
        {
            currentTime += Time.deltaTime / timeToFadeInHealthBar;
            lerpingPos = Vector3.Lerp(higherPos, lowerPos, currentTime);
            healthBarUI.localPosition = lerpingPos;
            if (healthBarUI.localPosition == lowerPos)
            {
                step1Done = true;
                slideInDone = true;
                currentTime = 0;
                yield return null;
            }
            yield return null;
        }
    }

    private IEnumerator HealthBarSlideOut()
    {
        if (!step2Done)
        {
            currentTime += Time.deltaTime / timeToFadeOutHealthBar;
            lerpingPos = Vector3.Lerp(lowerPos, higherPos, currentTime);
            healthBarUI.localPosition = lerpingPos;
            if (healthBarUI.localPosition == higherPos)
            {
                step2Done = true;
                currentTime = 0;
                yield return null;
            }
            yield return null;
        }
    }

    //void Update()
    //{
    //    currentTime += Time.deltaTime / timeToFadeIn;
    //    canvasGroup.alpha += currentTime;
    //    if(canvasGroup.alpha >= 1)
    //    {
    //        canvasGroup.alpha = 1;
    //        this.enabled = false;
    //    }
    //}
}
