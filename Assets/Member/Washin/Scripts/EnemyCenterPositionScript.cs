using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCenterPositionScript : MonoBehaviour
{
    public static EnemyCenterPositionScript instance;

    private void Awake()
    {
        instance = this;
    }

    public Vector3 GetCenterOfSpawnPosition()
    {
        return this.transform.position;
    }
}
