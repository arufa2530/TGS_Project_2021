using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowField : MonoBehaviour
{
    [SerializeField] [Range(0.5f,1.0f)] float slowAmountFrom0to1;
    PlayerMovement playerMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out playerMove))
        {
            playerMove.SetMoveSpeed(slowAmountFrom0to1);
            Debug.Log("Current Speed Is " + playerMove.GetCurrentMoveSpeed());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out playerMove))
        {
            playerMove.SetMoveSpeedToDefault();
            Debug.Log("Current Speed Is " + playerMove.GetCurrentMoveSpeed());
        }
    }
}
