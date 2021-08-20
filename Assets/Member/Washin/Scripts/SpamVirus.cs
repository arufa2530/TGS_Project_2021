using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpamVirus : MonoBehaviour
{
    [SerializeField]
    GameObject virus;

    [SerializeField]
    float spawnDelay;

    [SerializeField]
    int maxCount;

    Vector3 ranPos;

    GameObject goVirus;

    private void Start()
    {
        StartCoroutine(SpamVirusGradually());
    }

    IEnumerator SpamVirusGradually()
    {
        while (transform.childCount < maxCount)
        {
            ranPos = new Vector3(Random.Range(-300, 300), Random.Range(-220, 220), -0.01f);
            goVirus = Instantiate(virus, ranPos, Quaternion.identity, transform);

            if (spawnDelay > 0.1f)
                spawnDelay -= 0.05f;
            yield return new WaitForSeconds(spawnDelay);
        }
        Debug.Log("Stopped");
        StopCoroutine(SpamVirusGradually());

    }
}