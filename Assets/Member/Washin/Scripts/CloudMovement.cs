using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudMovement : MonoBehaviour
{

    [SerializeField] float timeToMoveInSeconds;
    float currentTime;
    public Vector3 startPos;
    float endX;
    Vector3 target;
    [SerializeField] Sprite[] lightClouds;
    [SerializeField] Sprite[] darkClouds;

    private void Awake()
    {
        SetStartingValues(transform.position.x);
    }

    public void SetTimeToMove(float multiply)
    {
        timeToMoveInSeconds = timeToMoveInSeconds * multiply;
    }

    public void SetStartingValues(float endPosX)
    {
        startPos = transform.position;
        endX = Mathf.Abs(endPosX) * -1;
        target = new Vector3(endX, transform.position.y, 0);
        GetComponentInChildren<Image>().sprite = GetRandomCloud();
        timeToMoveInSeconds = UnityEngine.Random.Range(timeToMoveInSeconds, timeToMoveInSeconds + timeToMoveInSeconds / 1.5f);
    }

    private Sprite GetRandomCloud()
    {
        int tempNumber = UnityEngine.Random.Range(0, 2);

        if (tempNumber == 0)
        {
            GetRandomScale();
            return lightClouds[UnityEngine.Random.Range(0, lightClouds.Length)];
        }
        GetRandomScale();
        return darkClouds[UnityEngine.Random.Range(0, darkClouds.Length)];
    }

    private void GetRandomScale()
    {
        transform.localScale = UnityEngine.Random.Range(0, 2) == 0 ? Vector3.one : new Vector3(-1,1,1);
    }

    private void Update()
    {
        currentTime += Time.deltaTime / timeToMoveInSeconds;
        transform.position = Vector3.Lerp(startPos, target, currentTime);
        if (transform.position.x == endX)
        {
            Destroy(this.gameObject);
        }
    }

}
