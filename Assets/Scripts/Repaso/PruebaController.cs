using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaController : MonoBehaviour
{

    public float goombaSpeed = 5;
    public float goombaJump = 13;
    float inputHorizontal;
    
    
    private Rigidbody2D _rigidBody;
    private GroundJump _groundJump;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundJump = GetComponentInChildren<GroundJump>();
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && _groundJump.isGorunded)
        {
           _rigidBody.AddForce(Vector2.up * goombaJump, ForceMode2D.Impulse);
        }

        if(inputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(inputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(inputHorizontal * goombaSpeed, _rigidBody.velocity.y);
    }

}
