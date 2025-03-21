using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip _boxSFX;
    public SpriteRenderer _spriteRendered;
    public BoxCollider2D _collider1;
    public BoxCollider2D _collider2;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRendered = GetComponent<SpriteRenderer>();
    }

    void DestroyBox()
    {
        _audioSource.clip = _boxSFX;
        _audioSource.Play();

        _spriteRendered.enabled = false;
        _collider1.enabled = false;
        _collider2.enabled = false;

        Destroy(gameObject, _boxSFX.length);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            DestroyBox();
        }
    }


}
