using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEnemyNumPadScript : MonoBehaviour
{
    [SerializeField] EnemyMovementScript enemyMoveScript;
    [SerializeField] SpawnBulletFromPool enemySpawnBulletScript;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Keypad7)) ToggleEnemyCanMove();
        if (Input.GetKeyDown(KeyCode.Keypad8)) ToggleEnemyMoveLeftAndRight();
        if (Input.GetKeyDown(KeyCode.Keypad9)) ToggleEnemyMoveToCenter();
        if (Input.GetKeyDown(KeyCode.Keypad4)) ToggleShootInArcPattern();
        if (Input.GetKeyDown(KeyCode.Keypad5)) ToggleShootInSpiralPattern();
        if (Input.GetKeyDown(KeyCode.Keypad6)) ToggleSpawnInCircleAroundEnemey();
        if (Input.GetKeyDown(KeyCode.Keypad0)) ToggleIsFirstPass();
    }

    private void ToggleEnemyCanMove()
    {
        if (enemyMoveScript.elaspedTime != 0) return;
        if (!enemyMoveScript.shouldMoveToCenter && !enemyMoveScript.shouldMoveLeftAndRight) return;
        enemyMoveScript.canMove = !enemyMoveScript.canMove;
    }

    private void ToggleEnemyMoveLeftAndRight()
    {
        if (enemyMoveScript.canMove) return;
        //if (enemyMoveScript.shouldMoveLeftAndRight) return;
        if (enemyMoveScript.shouldMoveToCenter == true) enemyMoveScript.shouldMoveToCenter = false;
        enemyMoveScript.shouldMoveLeftAndRight = true;
        enemyMoveScript.canMove = true;
    }

    private void ToggleEnemyMoveToCenter()
    {
        if (enemyMoveScript.canMove) return;
        if (enemyMoveScript.shouldMoveToCenter) { ToggleEnemyMoveLeftAndRight(); return; }
        if (enemyMoveScript.shouldMoveLeftAndRight == true) enemyMoveScript.shouldMoveLeftAndRight = false;
        enemyMoveScript.shouldMoveToCenter = true;
        enemyMoveScript.canMove = true;
    }

    private void ToggleShootInArcPattern()
    {
        if (enemySpawnBulletScript.shootBulletsSpiralPattern) enemySpawnBulletScript.shootBulletsSpiralPattern = false;
        enemySpawnBulletScript.shootBulletsArcPattern = !enemySpawnBulletScript.shootBulletsArcPattern;
    }

    private void ToggleShootInSpiralPattern()
    {
        if (enemySpawnBulletScript.shootBulletsArcPattern) enemySpawnBulletScript.shootBulletsArcPattern = false;
        enemySpawnBulletScript.shootBulletsSpiralPattern = !enemySpawnBulletScript.shootBulletsSpiralPattern;
    }

    private void ToggleSpawnInCircleAroundEnemey()
    {
        enemySpawnBulletScript.spawnBulletsAroundEnemy = !enemySpawnBulletScript.spawnBulletsAroundEnemy;
    }

    private void ToggleIsFirstPass()
    {
        enemySpawnBulletScript.isFirstPass = true;
    }
}
