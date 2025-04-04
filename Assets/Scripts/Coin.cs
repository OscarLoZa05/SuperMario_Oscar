using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    private AudioSource _audioSource;
    public AudioClip coinSFX;
    private SpriteRenderer _spriteRendered;

    private GameManager _gameManager;
    
    void Awake()
    {
       _animator = GetComponent<Animator>();
       _boxCollider2D = GetComponent<BoxCollider2D>();
       _audioSource = GetComponent<AudioSource>();
       _spriteRendered = GetComponent<SpriteRenderer>();
       _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

 
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            TakeCoin();          
        }
    }

    void TakeCoin()
    {
        _boxCollider2D.enabled = false;
        _gameManager.AddCoins();
        _spriteRendered.enabled = false;
        _audioSource.PlayOneShot(coinSFX);
        Destroy(gameObject, 1f);
        
    }
}