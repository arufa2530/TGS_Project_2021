using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    public static PlayerShootingScript instance;
    [SerializeField] public Transform shootFromHere;
    [SerializeField] Transform playerBulletHolder;
    public static bool CanShoot;
    public float currentTime;
    public float fireRate;
    public float bulletSpeed;

    private void Awake()
    {
        if (instance != null) { Destroy(this.gameObject);return; }

        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) CanShoot = !CanShoot;
    }

    private void FixedUpdate()
    {
        if (CanShoot)
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

        PoolBulletScriptTest tempPoolBulletScript = tempPlayerBullet.GetComponent<PoolBulletScriptTest>();
        DestroyBulletScript tempDestroyBulletScript = tempPlayerBullet.GetComponent<DestroyBulletScript>();

        tempPoolBulletScript.SetBulletStartingPosition(shootFromHere.position);
        tempDestroyBulletScript.SetDespawnTimer(-2);
        tempPoolBulletScript.MoveBulletInThisDirection(tempDirection);
        tempPoolBulletScript.SetBulletSpeed(bulletSpeed);
        tempPlayerBullet.SetActive(true);
    }

    public void AllowShooting()
    {
        CanShoot = true;
    }

    public void StopShooting()
    {
        CanShoot = false;
    }

    public Vector3 GetPlayerCurrentPosition()
    {
        return shootFromHere.position;
    }

}
