using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerScript : MonoBehaviour
{
    [SerializeField]
    PlayerHealthScript _playerHealthScript;

    public void NoHealthRemaining()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        //Destroy(this.gameObject);
    }

    public void GotHit()
    {
        _playerHealthScript.TookDamage();
    }
}
