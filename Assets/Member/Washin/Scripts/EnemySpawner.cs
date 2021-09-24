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
        PlayerReferences.PlayerEnteredBattleStage();
        if (spawnEnemyOnStart) SpawnEnemy();
    }

    public GameObject SpawnEnemy()
    {
        GameObject tempEnemy = Instantiate(enemy);
        SetEnemyDifficulty(tempEnemy);
        tempEnemy.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        return tempEnemy;
    }

    void SetEnemyDifficulty(GameObject _enemy)
    {
        HealthBarScript tempEnemyHealth = _enemy.GetComponentInChildren<HealthBarScript>();
        EnemyActions tempEnemyActions = _enemy.GetComponentInChildren<EnemyActions>();
        switch (PlayerReferences.battleStageCount)
        {
            case 1:
                tempEnemyHealth.SetMaxHealth(50);
                tempEnemyActions.SetSingleShot(true);
                break;
            case 2:
                tempEnemyHealth.SetMaxHealth(100);
                //tempEnemyActions.SetOnlyArc(true);
                break;
            //case 3:
            //    tempEnemyHealth.SetMaxHealth(150);
            //    break;
            default:
                Debug.LogError("OutSideOfRange");
                break;
        }
    }
}
