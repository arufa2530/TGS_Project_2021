using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] bool spawnEnemyOnStart;
    [SerializeField] GameObject enemy;
    void Start()
    {
        if (spawnEnemyOnStart) SpawnEnemy();
    }

    public GameObject SpawnEnemy()
    {
        GameObject tempEnemy = Instantiate(enemy);
        tempEnemy.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        return tempEnemy;
    }
}
