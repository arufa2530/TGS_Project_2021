using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnPositionScript : MonoBehaviour
{
    public static EnemyBulletSpawnPositionScript instance;

    private void Awake()
    {
        instance = this;
    }

    public Vector3 GetCenterOfSpawnPosition()
    {
        return this.transform.position;
    }
}
