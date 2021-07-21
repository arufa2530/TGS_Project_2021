using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentEnemyAction
{
    Idle,
    Moving,
    Shooting,
    Dying
}

public enum CurrentAttackPattern
{
    Arc,
    Spiral,
    None

}

public enum CurrentMovementPattern
{
    LeftAndRight,
    ToCenter,
    None
}

public class EnemyActions : MonoBehaviour
{
    [SerializeField] EnemyMovementScript moveEnemy;
    [SerializeField] SpawnBulletFromPool shootFromEnemy;

    [SerializeField] CurrentEnemyAction lastState = CurrentEnemyAction.Shooting;
    [SerializeField] public CurrentEnemyAction currentActionState;
    [SerializeField] CurrentMovementPattern currentMoveState;
    [SerializeField] float currentTime;
    [SerializeField] CurrentAttackPattern currentAttack;
    float idleTime = 3f;
    float movingTime = 3f;
    float shootingTime = 3f;


    // Start is called before the first frame update
    void Start()
    {
        currentActionState = CurrentEnemyAction.Idle;
        lastState = CurrentEnemyAction.Moving;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentActionState == CurrentEnemyAction.Dying)
        {
            moveEnemy.canMove = false;
            shootFromEnemy.shootBulletsArcPattern = false;
            shootFromEnemy.shootBulletsSpiralPattern = false;
            shootFromEnemy.spawnBulletsAroundEnemy = false;
            return;
        }

        if (currentActionState == CurrentEnemyAction.Idle)
        {
            if (currentAttack != CurrentAttackPattern.None) currentAttack = CurrentAttackPattern.None;
            PreformIdle();
        }

        if (currentActionState == CurrentEnemyAction.Moving)
        {
            currentTime += Time.deltaTime;
            if (currentMoveState == CurrentMovementPattern.None) ChooseRandomMovement();
            if (currentTime < movingTime + 0.1f)
            {
                return;
            }
            currentTime = 0;
            moveEnemy.canMove = false;
            moveEnemy.shouldMoveLeftAndRight = false;
            moveEnemy.shouldMoveToCenter = false;
            currentMoveState = CurrentMovementPattern.None;
            NextState();
        }

        if (currentActionState == CurrentEnemyAction.Shooting)
        {
            if (currentAttack == CurrentAttackPattern.None) ChooseRandomAttack();
            currentTime += Time.deltaTime;
            if (currentTime < shootingTime)
            {
                return;
            }
            currentTime = 0;
            shootFromEnemy.shootBulletsArcPattern = false;
            shootFromEnemy.shootBulletsSpiralPattern = false;
            currentAttack = CurrentAttackPattern.None;
            NextState();
        }
    }

    private void ChooseRandomMovement()
    {
        int i = UnityEngine.Random.Range(0, 2);

        if (i == 0) //move left and right
        {
            currentMoveState = CurrentMovementPattern.LeftAndRight;
            moveEnemy.shouldMoveLeftAndRight = true;
        }
        else //move to center
        {
            currentMoveState = CurrentMovementPattern.ToCenter;
            moveEnemy.shouldMoveToCenter = true;
        }

        moveEnemy.canMove = true;
    }

    void ChooseRandomAttack()
    {

        int i = UnityEngine.Random.Range(0, 2);

        if (i == 0) //shoot in an arc pattern
        {
            shootFromEnemy.shootBulletsArcPattern = true;
            currentAttack = CurrentAttackPattern.Arc;
        }
        else //shoot in a spiral pattern
        {
            shootFromEnemy.shootBulletsSpiralPattern = true;
            currentAttack = CurrentAttackPattern.Spiral;

        }
    }

    void SetCurrentStateToLastState()
    {
        lastState = currentActionState;
    }

    void NextState()
    {
        if (lastState == CurrentEnemyAction.Moving)
        {
            currentActionState = CurrentEnemyAction.Shooting;
            SetCurrentStateToLastState();
        }
        else if (lastState == CurrentEnemyAction.Shooting)
        {
            currentActionState = CurrentEnemyAction.Moving;
            SetCurrentStateToLastState();
        }
    }

    void PreformIdle()
    {
        currentTime += Time.deltaTime;
        if (currentTime < idleTime)
        {
            return;
        }
        currentTime = 0;
        NextState();
    }
}
