using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    [SerializeField] Transform shootFromHere;
    [SerializeField] Transform playerBulletHolder;
    public bool ShouldBeShooting;
    public float currentTime;
    public float fireRate;
    public float bulletSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) ShouldBeShooting = !ShouldBeShooting;
    }

    private void FixedUpdate()
    {
        if (ShouldBeShooting)
        {
            currentTime += Time.fixedDeltaTime;
            if (currentTime >= fireRate)
            {
                ShootAtEnemy();
                currentTime = 0;
            }
        }
    }

    public void ShootAtEnemy()
    {
        GameObject tempPlayerBullet = ObjectPoolScript.Instance.SpawnFromPool(
            "EnemyBulletNonClickableGreen", shootFromHere.position, Quaternion.identity, playerBulletHolder);

        Vector3 tempDirection = EnemyCenterPositionScript.instance.GetCenterOfSpawnPosition() - shootFromHere.position;

        //Debug.Log(EnemyCenterPositionScript.instance.GetCenterOfSpawnPosition());
        //Debug.Log(shootFromHere.position);
        //Debug.Log("tempDirection: " + tempDirection);

        PoolBulletScriptTest tempPoolBulletScript = tempPlayerBullet.GetComponent<PoolBulletScriptTest>();
        DestroyBulletScript tempDestroyBulletScript = tempPlayerBullet.GetComponent<DestroyBulletScript>();

        tempPoolBulletScript.SetBulletStartingPosition(shootFromHere.position);
        tempDestroyBulletScript.SetDespawnTimer(-2);
        tempPoolBulletScript.MoveBulletInThisDirection(tempDirection);
        tempPoolBulletScript.SetBulletSpeed(bulletSpeed);
        tempPlayerBullet.SetActive(true);
    }

}
