using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnWindow : MonoBehaviour
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
    float delayBetweenSpawn;
    [SerializeField]
    private int numberOfWindows;
    private bool done = false;
    [SerializeField]
    ChangeScene _changeScene;

    private void Start()
    {
        StartCoroutine(SpamWindows());
    }

    void Update()
    {
        if (done)
            StopCoroutine(SpamWindows());
    }

    IEnumerator SpamWindows()
    {
        for (int i = 0; i < numberOfWindows; i++)
        {
            startingPosition = new Vector3(
                UnityEngine.Random.Range(randomStartingPositionRangeX.x, randomStartingPositionRangeX.y),
                UnityEngine.Random.Range(randomStartingPositionRangeY.x, randomStartingPositionRangeY.y));
            tempWindow = Instantiate(tempWindow, startingPosition, Quaternion.identity, transform);

            if (delayBetweenSpawn > 0.1)
            {
                delayBetweenSpawn -= 0.05f;
            }
            yield return new WaitForSeconds(delayBetweenSpawn);
        }
        done = true;
        PlayerReferences.finishSlowSpam = true;
        Debug.Log("SlowSpamFinished");

        yield return new WaitForSeconds(3.5f);

        AudioSource audioData = GetComponent<AudioSource>();
        audioData.Play();
        yield return new WaitWhile(() => audioData.isPlaying);

        _changeScene.LoadNextScene(4);

        yield return null;
    }
}
//UnityEngine.Random.Range(randomStartingPositionRangeX.x,randomStartingPositionRangeX)