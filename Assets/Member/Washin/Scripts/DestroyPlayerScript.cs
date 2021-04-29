using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerScript : MonoBehaviour
{

    private void Update()
    {
        CheckIfIsDead();
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
