using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWindows : MonoBehaviour
{
    [SerializeField]
    private GameObject tempWindow;
    [SerializeField]
    Vector3 startingPosition;
    [SerializeField]
    Vector2 randomStartingPositionRangeX;
    [SerializeField]
    Vector2 randomStartingPositionRangeY;
    Vector3 randomStart;
    [SerializeField]
    Vector3 offSetV3;
    [SerializeField]
    float delayBetweenSpawn;
    [SerializeField]
    private int numberOfWindows;
    private int doneSpamming = 0;
    private Vector3 tempZ = Vector3.zero;
    private Vector3 tempY = new Vector3(0, -1, 0);
    [SerializeField]

    private void Start()
    {
        StartCoroutine(SpamWindows());

        
    }

    void Update()
    {
        if (doneSpamming==2)
            StopCoroutine(SpamWindows());
    }

    IEnumerator SpamWindows()
    {
        startingPosition = new Vector3(
                UnityEngine.Random.Range(randomStartingPositionRangeX.x, randomStartingPositionRangeX.y),
                UnityEngine.Random.Range(randomStartingPositionRangeY.x, randomStartingPositionRangeY.y));
        //Debug.Log(startingPosition);
        yield return new WaitUntil(() => PlayerReferences.finishSlowSpam == true);
        for (int i = 0; i < numberOfWindows; i++)
        {
            tempWindow = Instantiate(tempWindow, startingPosition + (offSetV3 * i), Quaternion.identity, transform);
            tempZ.z = i * -0.05f;
            tempWindow.transform.localPosition = tempWindow.transform.position + tempZ;
            if (tempWindow.transform.localPosition.y < -150)
            {
                startingPosition.x = randomStartingPositionRangeX.x;
                startingPosition.y = randomStartingPositionRangeY.x - (offSetV3.x * i);
            }
            if (delayBetweenSpawn > 0.08)
            {
                delayBetweenSpawn -= 0.01f;
            }
            //Debug.Log(tempWindow.transform.localPosition);
            yield return new WaitForSeconds(delayBetweenSpawn);
        }
        doneSpamming++;
        yield return null;
    }
}
//UnityEngine.Random.Range(randomStartingPositionRangeX.x,randomStartingPositionRangeX)