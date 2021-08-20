using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("EnemyHit!");
        if (collision.gameObject.CompareTag("PlayerBullet")) EnemyHPScript.instance.TakeDamage(collision.gameObject.GetComponent<BulletDamageScript>().GetBulletDamage());
    }
}
