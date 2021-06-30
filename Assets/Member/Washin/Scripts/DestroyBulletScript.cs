using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletScript : MonoBehaviour
{
    public bool canBeClicked;
    //public Vector3 tempStartingPoint;
    [SerializeField]
    private float currentTime;
    private float waitDelay = 1f;
    private float currentWaitTime = 0f;
    [SerializeField]
    private float timeToDespawn;
    private float timeToMove = 1f;

    private int Xoffset = 100;
    private int Yoffset = 100;

    [SerializeField]
    private Vector3 targetPos;

    [SerializeField]
    public string poolTag;

    private void OnMouseDown()
    {
        if (!canBeClicked) return;
        //Debug.Log("Clicked on " + gameObject.name);
        ReturnClickableToPool();
    }

    private void FixedUpdate()
    {
        if (timeToDespawn == -100) { Debug.LogError("DespawnTimerNotSet"); return; }
        if (timeToDespawn == -2) return;
        if (timeToDespawn == -1)
        {
            currentWaitTime += Time.fixedDeltaTime;
            if (currentWaitTime > timeToMove / 2)
            {
                currentTime += Time.fixedDeltaTime;
                MoveToRandomNearByPosition();
                if (currentTime >= timeToMove)
                    timeToDespawn = -2;
            }
            return;
        }

        currentTime += Time.fixedDeltaTime;
        if (currentTime > timeToDespawn)
        {
            ReturnClickableToPool();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (this.CompareTag("PlayerBullet") && collision.gameObject.CompareTag("Enemy")) { PlayerHitEnemy(); return; }
        if (this.CompareTag("PlayerBullet") && collision.gameObject.CompareTag("Player")) { return; }
        if (this.CompareTag("PlayerBullet") && collision.gameObject.CompareTag("Bullet"))
        { 
            Debug.Log("PlayerBulletHitENemyBullet");
            collision.gameObject.GetComponent<DestroyBulletScript>().ReturnClickableToPool();
            ReturnClickableToPool();
            return;
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet")) return;
        if (collision.gameObject.CompareTag("Walls")) return;
        if (collision.gameObject.CompareTag("OnHitDespawn")) { ReturnClickableToPool(); return; }


        if (!canBeClicked)
        {
            //Vector3 tempRotationCalc = tempStartingPoint - collision.transform.position;
            //Quaternion tempRotation = Quaternion.LookRotation(tempRotationCalc, Vector2.up);
            //tempRotation.z = tempRotation.x;
            //tempRotation.x = 0;
            //tempRotation.y = 0;
            BulletOnCollisionExplosionScript.instance.SpawnExplosionAtLocation(
            this.transform.position + new Vector3(0, 20, 0.03f));
        }
        ReturnClickableToPool();
    }

    public void ReturnClickableToPool()
    {
        currentTime = 0;
        if (poolTag == "EnemyBulletNonClickableYellow")
            ObjectPoolScript.Instance.ReturnToPool("EnemyBulletNonClickableYellow", this.gameObject);
        else if (poolTag == ("EnemyBulletClickableRed"))
            ObjectPoolScript.Instance.ReturnToPool("EnemyBulletClickableRed", this.gameObject);
        else if (poolTag == ("EnemyBulletNonClickableGreen"))
            ObjectPoolScript.Instance.ReturnToPool("EnemyBulletNonClickableGreen", this.gameObject);
    }

    //If set to -1 bullet will not despawn on its own
    //If set to -2 bullet will not despawn or move on its own
    public void SetDespawnTimer(float timeUntilDespawn)
    {
        timeToDespawn = timeUntilDespawn;
    }

    public void MoveToRandomNearByPosition()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, currentTime / timeToMove);
    }

    public void GetRandomPosition(Vector3 currentPos)
    {
        targetPos = currentPos;
        while (
            (targetPos.x < currentPos.x + Xoffset && targetPos.x > currentPos.x - Xoffset) &&
            (targetPos.y < currentPos.y + Yoffset && targetPos.y > currentPos.y - Yoffset))
        {
            targetPos = new Vector3(
                Random.Range(currentPos.x - Xoffset * 2, currentPos.x + Xoffset * 2),
                Random.Range(currentPos.y - Yoffset * 2, currentPos.y + Yoffset * 2), 0);
        }
    }

    public void ResetValues()
    {
        currentWaitTime = 0f;
        targetPos = Vector3.zero;
    }

    public void PlayerHitEnemy()
    {
        //Debug.Log("EnemyHit!");
        ReturnClickableToPool();
        return;
    }

}
