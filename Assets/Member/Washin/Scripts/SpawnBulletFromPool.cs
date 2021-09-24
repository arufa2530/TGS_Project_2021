using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletFromPool : MonoBehaviour
{
    GameObject temp;
    float currentTime = 0;
    float spawnDelay = 1;

    int tempStep = 0;

    [SerializeField]
    Transform currentBulletHolderTransform;
    [SerializeField]Transform clickableHolder;

    [SerializeField]
    float positionOffsetFactor;

    [SerializeField]
    public bool shootBulletsArcPattern;

    [SerializeField] float startingArc;
    [SerializeField] float endingArc;
    [SerializeField] int bulletsPerArc;
    [SerializeField] float fireRateArc;
    [SerializeField] float timeBetweenSingleShots;


    [SerializeField]
    public bool shootBulletsSpiralPattern;
    [SerializeField]
    public bool spawnBulletsAroundEnemy;
    [SerializeField]
    public bool shootSingleBullet;
    [SerializeField]
    public bool isFirstPass;

    private string nonClickableBulletYellow = "EnemyBulletNonClickableYellow";
    private string clickableBulletRed = "EnemyBulletClickableRed";
    private string nonclickableBulletGreen = "EnemyBulletNonClickableGreen";


    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if (shootBulletsArcPattern)
        {
            if (currentTime > fireRateArc)
            {
                //SpawnRandomBullet();
                SpawnBulletPattern(nonClickableBulletYellow, 2, startingArc, endingArc, bulletsPerArc);
                currentTime = 0;
            }
        }

        if (shootSingleBullet)
        {
            if (currentTime > timeBetweenSingleShots)
            {
                //SpawnOneBullet
                ShootAtPlayer(nonClickableBulletYellow, 1f);
                currentTime = 0;
            }
        }

        if (shootBulletsSpiralPattern)
        {
            if (currentTime > 0.3f)
            {
                if (isFirstPass)
                {
                    SpawnBulletsInACircleAroundEnemy(nonClickableBulletYellow, -2, 10, false);
                    isFirstPass = false;
                }
                SpawnBulletsInASpiralAroundEnemy(nonClickableBulletYellow, 2.75f, -2, tempStep, 7);
                tempStep += 5;
                currentTime = 0;
            }
        }

        if (spawnBulletsAroundEnemy)
        {
            if (currentTime > spawnDelay)
            {
                SpawnBulletsInACircleAroundEnemy(clickableBulletRed, -1, 10, true);
                currentTime = 0;
            }
        }
    }

    public void ShootAtPlayer(string typeOfBulletToSpawn, float bulletSpeed)
    {
        if (EnemyCenterPositionScript.instance == null) return;

        Vector3 tempPlayerPos = PlayerShootingScript.instance.shootFromHere.position;

        GameObject tempEnemyBullet = ObjectPoolScript.Instance.SpawnFromPool(
            typeOfBulletToSpawn, EnemyBulletSpawnPositionScript.instance.GetCenterOfSpawnPosition(), Quaternion.identity, ObjectPoolScript.Instance.GetbulletPoolTransForm());

        Vector3 tempDirection = tempPlayerPos - EnemyCenterPositionScript.instance.GetCenterOfSpawnPosition();

        PoolBulletScriptTest tempPoolBulletScript = tempEnemyBullet.GetComponent<PoolBulletScriptTest>();
        DestroyBulletScript tempDestroyBulletScript = tempEnemyBullet.GetComponent<DestroyBulletScript>();

        tempPoolBulletScript.SetBulletStartingPosition(EnemyBulletSpawnPositionScript.instance.GetCenterOfSpawnPosition());
        tempDestroyBulletScript.SetDespawnTimer(-2);
        tempPoolBulletScript.MoveBulletInThisDirection(tempDirection);
        tempPoolBulletScript.SetBulletSpeed(bulletSpeed);
        tempEnemyBullet.SetActive(true);
    }

    public void SpawnBulletsInASpiralAroundEnemy(
        string typeOfBulletToSpawn, float bulletSpeed, float despawnTimer,
        int stepAngle, int bulletsPerWave)
    {
        float angleOffset = 360 / bulletsPerWave;
        float currentAngle = stepAngle;
        for (int i = 0; i < bulletsPerWave; i++)
        {
            GameObject tempBullet = GetBulletFromPoolAsGameObject(typeOfBulletToSpawn, GetEnemyCenterPositon());
            float tempVecX = this.transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180) * positionOffsetFactor;
            float tempVecY = this.transform.position.y + Mathf.Cos((currentAngle * Mathf.PI) / 180) * positionOffsetFactor;
            Vector3 tempDirection = new Vector3(tempVecX - this.transform.position.x, tempVecY - this.transform.position.y, 0);

            PoolBulletScriptTest tempPoolBulletScript = tempBullet.GetComponent<PoolBulletScriptTest>();
            DestroyBulletScript tempDestroyBulletScript = tempBullet.gameObject.GetComponent<DestroyBulletScript>();

            tempPoolBulletScript.SetBulletStartingPosition(tempDirection + this.transform.position);
            tempDestroyBulletScript.SetDespawnTimer(despawnTimer);
            tempPoolBulletScript.MoveBulletInThisDirection(tempDirection);
            tempPoolBulletScript.SetBulletSpeed(bulletSpeed);


            tempBullet.gameObject.transform.SetParent(currentBulletHolderTransform);
            tempBullet.SetActive(true);

            currentAngle += angleOffset;
        }
    }

    public void SpawnBulletPattern(
        string typeOfBulletToSpawn, float despawnTimer,
        float startingAngle, float endingAngle, int bulletsPerWave)
    {
        float angleOffset = (endingAngle - startingAngle) / bulletsPerWave;
        float currentAngle = startingAngle;

        for (int i = 0; i < bulletsPerWave + 1; i++)
        {
            GameObject tempBullet = GetBulletFromPoolAsGameObject(typeOfBulletToSpawn,
                EnemyBulletSpawnPositionScript.instance.GetCenterOfSpawnPosition());

            float tempVecX = this.transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180);
            float tempVecY = this.transform.position.y + Mathf.Cos((currentAngle * Mathf.PI) / 180);
            Vector2 tempDirection = new Vector3(tempVecX - this.transform.position.x, tempVecY - this.transform.position.y, 0);

            tempBullet.gameObject.GetComponent<PoolBulletScriptTest>().MoveBulletInThisDirection(tempDirection * 8);
            tempBullet.gameObject.GetComponent<DestroyBulletScript>().SetDespawnTimer(despawnTimer);
            tempBullet.SetActive(true);

            currentAngle += angleOffset;
        }
    }

    public void SpawnBulletsInACircleAroundEnemy(
        string typeOfBulletToSpawn, float despawnTimer,
        int bulletsPerWave,
        bool shouldMoveToRandomPosition)
    {
        float angleOffset = 360 / bulletsPerWave;
        float currentAngle = 0;
        for (int i = 0; i < bulletsPerWave; i++)
        {
            GameObject tempBullet = GetBulletFromPoolAsGameObject(typeOfBulletToSpawn, GetEnemyCenterPositon());
            float tempVecX = this.transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180) * positionOffsetFactor;
            float tempVecY = this.transform.position.y + Mathf.Cos((currentAngle * Mathf.PI) / 180) * positionOffsetFactor;
            Vector3 tempDirection = new Vector3(tempVecX, tempVecY, 0);

            PoolBulletScriptTest tempPoolBulletScript = tempBullet.GetComponent<PoolBulletScriptTest>();
            DestroyBulletScript tempDestroyBulletScript = tempBullet.gameObject.GetComponent<DestroyBulletScript>();

            tempPoolBulletScript.SetBulletStartingPosition(tempDirection);
            tempPoolBulletScript.MoveBulletInThisDirection(Vector3.zero);
            tempDestroyBulletScript.SetDespawnTimer(despawnTimer);
            if (shouldMoveToRandomPosition)
            {
                tempDestroyBulletScript.GetRandomPosition(GetEnemyCenterPositon());
            }
            tempBullet.gameObject.transform.SetParent(clickableHolder);
            tempBullet.SetActive(true);

            currentAngle += angleOffset;
        }

        spawnBulletsAroundEnemy = false;
    }

    private GameObject GetBulletFromPoolAsGameObject(string typeOfBulletToSpawn, Vector3 bulletPosition)
    {
        GameObject tempBullet = ObjectPoolScript.Instance.SpawnFromPool(typeOfBulletToSpawn,
        bulletPosition,
        Quaternion.identity,
        ObjectPoolScript.Instance.GetbulletPoolTransForm());

        SetBulletCanBeClickedOrNot(typeOfBulletToSpawn, tempBullet);
        return tempBullet;
    }

    private void SetBulletCanBeClickedOrNot(string typeOfBulletToSpawn, GameObject tempbullet)
    {
        if (typeOfBulletToSpawn == nonClickableBulletYellow)
            tempbullet.GetComponent<DestroyBulletScript>().canBeClicked = false;
        else if (typeOfBulletToSpawn == clickableBulletRed)
        {
            tempbullet.GetComponent<DestroyBulletScript>().canBeClicked = true;
        }
    }

    public void SpawnRandomBullet()
    {
        if (Random.Range(0, 2) == 0)
            SpawnBullet(nonClickableBulletYellow);
        else
            SpawnBullet(clickableBulletRed);
    }

    public void SpawnBullet(string typeOfBulletToSpawn)
    {
        GameObject tempbullet = GetBulletFromPoolAsGameObject(typeOfBulletToSpawn,
            EnemyBulletSpawnPositionScript.instance.GetCenterOfSpawnPosition());

        if (typeOfBulletToSpawn == nonClickableBulletYellow || typeOfBulletToSpawn == nonclickableBulletGreen)
            tempbullet.GetComponent<DestroyBulletScript>().canBeClicked = false;
        else if (typeOfBulletToSpawn == clickableBulletRed)
            tempbullet.GetComponent<DestroyBulletScript>().canBeClicked = true;

        tempbullet.SetActive(true);
    }

    public Vector3 GetEnemyCenterPositon()
    { return this.gameObject.transform.position; }
}
