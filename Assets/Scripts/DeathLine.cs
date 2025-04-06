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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            
            _playerCotroller.GameOverUI();
            
        }
    }




    
}
