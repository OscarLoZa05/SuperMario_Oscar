using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLine : MonoBehaviour
{
    
    private BoxCollider2D _boxCollider2D;
    private PlayerCotroller _playerCotroller;

    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _playerCotroller = FindObjectOfType<PlayerCotroller>().GetComponent<PlayerCotroller>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            _playerCotroller.GameOverUI();
            
        }
    }




    
}
