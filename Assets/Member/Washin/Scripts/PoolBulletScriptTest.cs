using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBulletScriptTest : MonoBehaviour
{
    [SerializeField]
    Vector3 directionVector = Vector3.zero;
    float bulletSpeed = 30f;

    private void FixedUpdate()
    {
        transform.Translate(directionVector * bulletSpeed * Time.fixedDeltaTime);
    }

    public void MoveBulletInThisDirection(Vector3 directionToMoveTo)
    {
        directionVector = directionToMoveTo;
    }

    public void SetBulletStartingPosition(Vector3 startingPos)
    {
        this.transform.position = startingPos;
    }

    public void SetBulletSpeed(float tempBulletSpeed)
    {
        bulletSpeed = tempBulletSpeed;
    }

    public void ResetValues()
    {
        bulletSpeed = 30f;
        directionVector = Vector3.zero;
    }
}
