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
    
    void Awake()
    {
       _animator = GetComponent<Animator>();
       _boxCollider2D = GetComponent<BoxCollider2D>();
       _audioSource = GetComponent<AudioSource>();
       _spriteRendered = GetComponent<SpriteRenderer>();
    }

 
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _spriteRendered.enabled = false;
            _audioSource.PlayOneShot(coinSFX);
            Destroy(gameObject, 1f);

        }
    }

}
