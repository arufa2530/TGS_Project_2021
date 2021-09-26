using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToCombatScreen : MonoBehaviour
{
    private float delayBetweenSpawn = 0.1f;
    [SerializeField] private GameObject windowToSpam;
    private Vector3 positionToSpawnWindow;
    private Vector3 tempZ = Vector3.zero;
    private Vector3[] windowPoistions;
    private int numberOfWindows = 50;

    private void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        StartCoroutine(StartCoveringScreenWithWindows());
    }

    IEnumerator StartCoveringScreenWithWindows()
    {
        for (int i = 0; i < numberOfWindows; i++)
        {
            positionToSpawnWindow = new Vector3(
              UnityEngine.Random.Range(-320, 320),
              UnityEngine.Random.Range(-240, 240));

            tempZ.z = (i * -0.1f) + -2.25f;

            GameObject currentWindow = Instantiate(windowToSpam, positionToSpawnWindow + tempZ, Quaternion.identity, transform);
            currentWindow.GetComponent<AutoDespawnWindowScript>().enabled = true;

            if (delayBetweenSpawn > 0.08)
            {
                delayBetweenSpawn -= 0.01f;
            }
            yield return new WaitForSeconds(delayBetweenSpawn);
        }
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
        yield return null;
    }


}
