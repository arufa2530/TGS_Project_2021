using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    private float secondsLeft = 3f;

    private void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * bulletSpeed;
    }

    void Update()
    {
        secondsLeft -= Time.deltaTime;
        if (secondsLeft <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyPlayerScript _destroyPlayerScript = collision.gameObject.GetComponent<DestroyPlayerScript>();
            _destroyPlayerScript.GotHit();
        }
        Destroy(this.gameObject);
    }

}
