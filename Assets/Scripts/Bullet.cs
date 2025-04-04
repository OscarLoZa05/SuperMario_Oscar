using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float bulletForce = 10;
    public float bulletDamage = 0.5f;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

    }
   
    void Start()
    {
        _rigidBody.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            Enemy enemyScript = collider.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(bulletDamage);
            BulletDeath();
        }

        if(collider.gameObject.layer == 3)
        {
            BulletDeath();
        }
    }

    void BulletDeath()
    {
        Destroy(gameObject);
    }
}
