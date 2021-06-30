using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerScript : MonoBehaviour
{

    private void Update()
    {
        CheckIfIsDead();

        //Debug
        if (Input.GetKeyDown(KeyCode.Keypad1)) PlayerReferences.LostHealth(1);

    }

    private void CheckIfIsDead()
    {
        if (PlayerReferences.currentHealth == 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
