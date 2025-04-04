using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public bool isPlaying = true;
    public bool _isPaused = false;
    private SoundManager _soundManager;
    public GameObject pauseCanvas;
    public GameObject optionCanvas;

    private int coins = 0;
    public Text coinsText;

    void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();

    }

    void Start()
    {
        coinsText.text = "Coins: " + coins.ToString();
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Pause();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if(_isPaused)
        {

            Time.timeScale = 1;
            _isPaused = false;
            _soundManager.PauseBGM();
            pauseCanvas.SetActive(false);
            optionCanvas.SetActive(false);

        }
        
        else
        {
            Time.timeScale = 0;
            _isPaused = true;
            _soundManager.PauseBGM();
            pauseCanvas.SetActive(true);
        }
    }


    public void  AddCoins()
    {
        coins++;
        coinsText.text = "Coins: " + coins.ToString(); 
    }



}
