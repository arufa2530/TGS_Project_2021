using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldSpawnClouds : MonoBehaviour
{
    [SerializeField] bool shouldSpawnClouds;
    [SerializeField] GameObject cloudPrefab;
    [SerializeField] GameObject startTop, startBottom;
    [SerializeField] float currentTime;
    [SerializeField] float timeToSpawn;
    [SerializeField] int largestClusterOfClouds;

    private void Start()
    {
        if (!shouldSpawnClouds) return;
        currentTime = timeToSpawn;
        for (int i = 0; i < 5; i++)
        {
            float tempStartX = Random.Range(-300, 300);
            GameObject tempCloud = SpawnClouds(tempStartX);
            CloudMovement tempMove = tempCloud.GetComponent<CloudMovement>();
            tempMove.SetTimeToMove(0.5f);
            tempMove.SetStartingValues(startTop.transform.position.x);
        }
    }

    private void Update()
    {
        if(shouldSpawnClouds)
        {
            if (currentTime < timeToSpawn)
                currentTime += Time.deltaTime / timeToSpawn;
            else
            {
                for (int i = 0; i < Random.Range(1,largestClusterOfClouds); i++)
                {
                    SpawnClouds(startTop.transform.position.x);
                }
                currentTime = 0;
            }
        }
    }

    GameObject SpawnClouds(float xPos)
    {
        Vector3 spawnPos = new Vector3(xPos, Random.Range(startBottom.transform.position.y, startTop.transform.position.y));
        GameObject tempCloud = Instantiate(cloudPrefab, spawnPos, Quaternion.identity, this.transform);
        return tempCloud;
    }


}
