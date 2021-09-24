using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOnCollisionExplosionScript : MonoBehaviour
{
    public static BulletOnCollisionExplosionScript instance;

    [SerializeField]
    GameObject explosionPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnExplosionAtLocation(Vector3 locationToSpawnExplosion)
    {
        if (explosionPrefab != null)
        {
            GameObject tempExplosion = Instantiate(explosionPrefab, locationToSpawnExplosion, Quaternion.identity, this.transform);
        }
    }
}
