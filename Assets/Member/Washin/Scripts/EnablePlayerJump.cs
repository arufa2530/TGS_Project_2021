using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayerJump : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerReferences.playerMovement.SetIsPlayerJumping(false);
            //Debug.Log("PlayerIsNotJumping");
        }
    }
}
