using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawnPopUp : MonoBehaviour
{
    [SerializeField] GameObject popUpPrefab;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnPopUp();
        }
    }

    private void SpawnPopUp()
    {
        Instantiate(popUpPrefab);
    }
}
