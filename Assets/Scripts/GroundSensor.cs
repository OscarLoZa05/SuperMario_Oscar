using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGorunded;

    void OnTriggerEnter2D(Collider2D collider)
    {
        isGorunded = true;
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        isGorunded = false;
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        isGorunded = true;
    }
}
