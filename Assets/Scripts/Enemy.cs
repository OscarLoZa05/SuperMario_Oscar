using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

private Animator _animator;
private AudioSource _audioSource;
public AudioClip _deathSFX;
private Rigidbody2D _rigidBody;
private BoxCollider2D _boxCollider2D;

public int direction = 1;
public float speed = 5;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

    }

    

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
    }

    public void Death()
    {
        direction = 0;
        _rigidBody.gravityScale = 0;
        _animator.SetTrigger("IsDead");
        _boxCollider2D.enabled = false;
        Destroy(gameObject, 0.3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;

        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}


