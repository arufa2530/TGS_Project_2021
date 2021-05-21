using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletFromPool : MonoBehaviour
{
    Vector3 spawnHere;
    GameObject temp;

    private void Awake()
    {
        spawnHere = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 10, 0);
    }

    private void FixedUpdate()
    {
        //objectPooler.SpawnFromPool("EnemyBullet", spawnHere, Quaternion.identity).SetActive(true);
        ObjectPoolScript.Instance.SpawnFromPool("EnemyBullet", spawnHere, Quaternion.identity).SetActive(true);
    }

}
