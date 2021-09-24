using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleFadeIn : MonoBehaviour
{
    [SerializeField] SpeechBubbleMovement speechBubbleMove;
    [SerializeField] bool startFade = false;
    [SerializeField] float fadeInTime;
    [SerializeField] float currentTime;
    [SerializeField] SpriteRenderer bubbleIcon;
    [SerializeField] SpriteRenderer innerIcon;
    Color color = new Color(1,1,1,0);

    private void Start()
    {
        if (fadeInTime <= 0) Debug.LogError("CheckFadeInTime");
        bubbleIcon.color = color;
        innerIcon.color = color;
    }

    void Update()
    {
        if (!startFade) return;

        if (currentTime < fadeInTime)
        {
            currentTime += Time.deltaTime / fadeInTime;
            color.a = currentTime;
            bubbleIcon.color = color;
            innerIcon.color = color;
        }
        else
        {
            if(speechBubbleMove != null)
                speechBubbleMove.enabled = true;
            this.enabled = false;
        }
    }

    public void StartFade()
    {
        startFade = true;
    }
}
