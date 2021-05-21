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

    private void Update()
    {
        //MoveEnemy();
        //elaspedTime += Time.deltaTime;
        //if (elaspedTime >= timeToMove)
        //{
        //    currentPos = this.transform.position;
        //    elaspedTime = 0;
        //    PickNewPos();
        //}
    }

    void MoveEnemy()
    {
        transform.position = Vector2.Lerp(currentPos, targetPos, elaspedTime / timeToMove);
    }

    void PickNewPos()
    {
        while ((transform.position.x - 200 <= targetPos.x && targetPos.x <= transform.position.x + 200))
        {
            targetPos.x = Random.Range(rangeOfMotionHorizontal.x,rangeOfMotionHorizontal.y);
        }
    }
}
