using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleMovement : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    [SerializeField] float lerpTime;
    [SerializeField] float currentTime;

    private void Start()
    {
        if (lerpTime <= 0) Debug.LogError("CheckLerpTime");
        transform.position = pointA.position;
    }

    void Update()
    {
        currentTime += Time.deltaTime / lerpTime;
        this.transform.position = Vector3.Lerp(pointA.position, pointB.position, currentTime);
        if (this.transform.position == pointB.position)
        {
            FlipPoints();
            currentTime = 0;
        }
    }


    void FlipPoints()
    {
        Transform tempC = pointA;
        pointA = pointB;
        pointB = tempC;
    }
}
