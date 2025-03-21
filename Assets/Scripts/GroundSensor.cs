using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;
    //private Enemy _enemyScript;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
            /*Debug.Log(collider.gameObject.name);*/
        }
        
        else if(collider.gameObject.layer == 6)
        {
            Enemy _enemyScript = collider.gameObject.GetComponent<Enemy>();
            _enemyScript.Death();
        }
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
    
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }
}
