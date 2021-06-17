using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    private float elaspedTime;
    public float timeToMove;
    public float timeToMoveToCenter;

    public bool canMove;
    public bool shouldMoveLeftAndRight;
    public bool shouldMoveToCenter;

    [SerializeField]
    Vector3 tempLerpPos;

    Vector2 currentPos;
    [SerializeField]
    Vector2 targetPos;
    Rigidbody2D rb;

    [SerializeField]
    private Vector2 rangeOfMotionHorizontal = new Vector2(-640, 640);
    [SerializeField]
    private float topOfScreen = 190;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPos = new Vector2(0, topOfScreen);
        targetPos = currentPos;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            elaspedTime += Time.fixedDeltaTime;

            if (shouldMoveLeftAndRight)
            {
                MoveEnemy();
                if(IsTimeToMove())
                {
                    currentPos = this.transform.position;
                    DisableEnemyMovement();
                    PickNewPos();
                }
            }

            if(shouldMoveToCenter)
            {
                //MoveEnemyToCenter();
                MoveEnemyToCenter();
                if (IsTimeToMove())
                {
                    currentPos = this.transform.position;
                    DisableEnemyMovement();
                }
            }
        }
    }

    void MoveEnemy()
    {
        transform.position = Vector2.Lerp(currentPos, targetPos, elaspedTime / timeToMove);
    }

    void PickNewPos()
    {
        while ((transform.position.x - 200 <= targetPos.x && targetPos.x <= transform.position.x + 200))
        {
            targetPos.x = Random.Range(rangeOfMotionHorizontal.x, rangeOfMotionHorizontal.y);
        }
    }

    public void MoveEnemyToCenter()
    {
        transform.position = Vector2.Lerp(currentPos, Vector3.zero, elaspedTime / timeToMove);
    }

    public void SetEnemyPosition()
    {
        currentPos = targetPos;
    }

    public void DisableEnemyMovement()
    {
        canMove = false;
        elaspedTime = 0;
    }

    public void EnableEnemyMovement()
    {
        canMove = true;
    }

    public bool IsTimeToMove()
    {
        return elaspedTime >= timeToMove;
    }

}
