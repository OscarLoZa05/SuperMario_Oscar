using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip bgm;
    public AudioClip gameOver;
    public bool IsFinished = false;

    private GameManager _gameManager;
    public float delay = 2;
    public float timer;
    private bool timerFinished = false;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        
    }
    
    void Start()
    {
        PlayBGM();
    }

    
    void Update()
    {
        /*if(!_gameManager.isPlaying && !timerFinished)
        {
            DeathBGM();
        }*/    
    }

    void PlayBGM()
    {
        _audioSource.clip = bgm;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void PauseBGM()
    {
        if(_gameManager._isPaused || IsFinished)
        {
            _audioSource.Pause();
        }
        else
        {
            _audioSource.Play();
        }
        
    }

    /*public void ReanudeBGM()
    {
        _audioSource.Play();
    }*/
    /*public void DeathBGM()
    {
        _audioSource.Stop();

        timer += Time.deltaTime;

        if(timer >= delay)
        {
            timerFinished = true;
            _audioSource.PlayOneShot(gameOver);
        }
    }*/

    public IEnumerator DeathBGM()
    {
        _audioSource.Stop();
        yield return new WaitForSeconds(delay);
        _audioSource.PlayOneShot(gameOver);
    }




}

