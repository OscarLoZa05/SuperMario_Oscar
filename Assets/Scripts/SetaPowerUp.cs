using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaPowerUp : MonoBehaviour
{
    private float mushroomSpeed = 3;
    private int mushroomDirection = 1;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _rendered;
    
    private AudioSource _audioSource;
    public AudioClip powerUpSFX;

    // Start is called before the first frame update
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _rendered = GetComponent<SpriteRenderer>();
        
    }


    void Start()
    {

    }

    void FixedUpdate()
    {
        
        _rigidBody.velocity = new Vector2(mushroomDirection * mushroomSpeed, _rigidBody.velocity.y);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerCotroller playerScript = collision.gameObject.GetComponent<PlayerCotroller>();
            playerScript.canShoot = true;
            Interact();
        }

        if(collision.gameObject.CompareTag("Tuberia"))
        {
            mushroomDirection *= -1;
        }
    }


    void Interact()
    {
        mushroomDirection = 0;
        _rigidBody.gravityScale = 0;
        _boxCollider2D.enabled = false;
        _rendered.enabled = false;
        _audioSource.PlayOneShot(powerUpSFX);
        Destroy(gameObject, 1f);
    }
}
