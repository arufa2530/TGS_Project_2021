using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiringScript : MonoBehaviour
{

    [SerializeField]
    int damage;
    [SerializeField]
    float shotDelay;
    private float elapsedTime;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletHolder;
    [SerializeField]
    private Vector3 offSet = Vector3.zero;

    void Update()
    {
        if (elapsedTime > shotDelay)
        {
            elapsedTime = 0;
            Instantiate(bullet, bulletHolder.transform.position, Quaternion.identity, bulletHolder);
        }
        elapsedTime += Time.deltaTime;
    }
}
