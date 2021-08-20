using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    //private float secondsLeft = 3f;
    private float secondsLeft = 20f;
    private Vector3 startPos;
    private Vector3 pattern;
    private float startAngle = 0;
    private float currentAngle;
    private float maxAngle = 360;

    private void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        startPos = transform.GetComponentInParent<Transform>().position;
    }

    void Update()
    {
        secondsLeft -= Time.deltaTime;
        if (secondsLeft <= 0)
            Destroy(this.gameObject);

        currentAngle += Time.deltaTime;
        if (currentAngle >= maxAngle)
            currentAngle = startAngle;
        pattern += new Vector3(Mathf.Cos((startPos.x * Mathf.PI) - currentAngle) / 4, 0, 0);
        transform.localPosition = pattern;
    }

    private void FixedUpdate()
    {
        pattern.y = Mathf.Lerp(transform.localPosition.y, transform.localPosition.y - 30, Time.fixedDeltaTime / 2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Bullet"))
            return;
        if (collision.gameObject.CompareTag("Player"))
            PlayerReferences.LostHealth(1);
        Destroy(this.gameObject);
    }

}
