using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundJump : MonoBehaviour
{

    public bool isGorunded;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGorunded = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGorunded = false;
        }
        
    }
}
