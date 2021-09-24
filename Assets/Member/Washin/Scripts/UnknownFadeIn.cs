using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownFadeIn : MonoBehaviour
{
    [SerializeField] SpeechBubbleFadeIn fadeIn;
    [SerializeField] SpriteRenderer unknownRend;
    [SerializeField] float fadeInTime;
    [SerializeField] float currentTime;

    Color color = new Color(1, 1, 1, 0);

    private void Start()
    {
        unknownRend.color = color;
    }

    private void Update()
    {
        if (currentTime < 1)
        {
            currentTime += Time.deltaTime / fadeInTime;
            color.a = currentTime;
            unknownRend.color = color;
        }
        else
        {
            fadeIn.StartFade();
            this.enabled = false;
        }
    }


}
