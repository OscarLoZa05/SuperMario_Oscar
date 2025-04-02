using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    
private AudioSource _audioSource;
public AudioClip finishSFX;
private BoxCollider2D _boxCollider2D;
private SoundManager _soundManager;
    
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _soundManager.IsFinished = true;
            _soundManager.PauseBGM();
            _audioSource.PlayOneShot(finishSFX);
        }
    }
}
