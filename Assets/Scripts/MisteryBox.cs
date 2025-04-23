using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip _misteryBoxSFX;
    public AudioClip _misteryBoxOpenSFX;
    private bool  _isOpen = false;
    public Transform mushroomSpawn;
    public GameObject[] mushroomPrefab;
    public int powerUpIndex;
    public AudioClip _mushroomSFX;
    

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void ActivatedBox()
    {
        if(!_isOpen)
        {
            _animator.SetTrigger("OpenBox");
            
            _audioSource.clip = _misteryBoxSFX;
            
            Mushroom();
            
            _isOpen = true;

            

        }
        else
        {
            _audioSource.clip = _misteryBoxOpenSFX;
        }

        _audioSource.Play();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            ActivatedBox();
        }
    } 

    void Mushroom()
    {
        Instantiate(mushroomPrefab[powerUpIndex], mushroomSpawn.position, mushroomSpawn.rotation);
    }   
}
