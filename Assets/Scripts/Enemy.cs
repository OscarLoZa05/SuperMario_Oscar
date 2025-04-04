using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

private Animator _animator;
private AudioSource _audioSource;
public AudioClip _deathSFX;
public AudioClip _damageSFX;
private Rigidbody2D _rigidBody;
private BoxCollider2D _boxCollider2D;
private Slider _healthBar;
private SpriteRenderer _spriteRendered;

public int direction = 1;
public float speed = 3;

public float maxHealth = 20;
private float currentHealth;


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _healthBar = GetComponentInChildren<Slider>();
        _spriteRendered = GetComponent<SpriteRenderer>();

    }

    void Start()
    {
        speed = 0;

        currentHealth = maxHealth;
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;
    
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
        _audioSource.PlayOneShot(_deathSFX);
        Destroy(gameObject, 1f);
    }


    public void TakeDamage(float damage)
    {
        currentHealth-= damage;
        _healthBar.value = currentHealth;
        _audioSource.PlayOneShot(_damageSFX);

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Tuberia") || collision.gameObject.layer == 6) /*esto || es "o"*/
        {
            direction *= -1;
        }
        
        if(collision.gameObject.CompareTag("Player"))
        {
            
            //Destroy(collision.gameObject);
            PlayerCotroller playerScript = collision.gameObject.GetComponent<PlayerCotroller>();
            playerScript.Death();
        }
    }

     void OnTriggerEnter2D(Collider2D collider)
     {
        if(collider.gameObject.layer == 8)
        {
            direction *= -1;
        }
     }

    void OnBecameVisible()
    {
        speed = 3;
    }

    void OnBecameInvisible()
    {
        speed = 0;
    }
}



