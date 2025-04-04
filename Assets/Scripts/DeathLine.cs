using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLine : MonoBehaviour
{
    
    private BoxCollider2D _boxCollider2D;
    public GameObject _player;

    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            
            //Destroy(_player.gameObject);
        }
    }




    
}
