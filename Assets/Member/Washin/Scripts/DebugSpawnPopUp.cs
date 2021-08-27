using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawnPopUp : MonoBehaviour
{
    [SerializeField] GameObject popUpPrefab;
    [SerializeField] EnemyActions enemyActions;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPopUp();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            enemyActions.ShootOnce();
            Debug.Log("O Pressed");
        }
    }

    private void SpawnPopUp()
    {
        Instantiate(popUpPrefab);
    }
}
