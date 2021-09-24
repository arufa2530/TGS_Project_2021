using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFolderMoveToPosition : MonoBehaviour
{
    [SerializeField] SpeechBubbleFadeIn fadeIn;
    public Transform pointA;
    public Transform pointB;
    [SerializeField] float lerpTime;
    [SerializeField] float currentTime;

    void Update()
    {
        if (currentTime < 1)
        {
            currentTime += Time.deltaTime / lerpTime;
            this.transform.position = Vector3.Lerp(pointA.position, pointB.position, currentTime);
        }
        else
        {
            fadeIn.StartFade();
            this.enabled = false;
        }
    }
}
