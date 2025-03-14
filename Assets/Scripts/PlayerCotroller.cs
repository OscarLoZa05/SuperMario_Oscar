using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    public int direction = 1;
    public float playerSpeed = 4.5f;
    private float inputHorizontal;
    public float jumpForce = 10;
    private Rigidbody2D rigidBody;
    private GroundSensor _groundSensor;
    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Esto teletransporta al personaje
        //transform.position = new Vector3 (-108.75f,-5.5f, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetButtonDown("Jump") && _groundSensor.isGorunded) //dos == es para comprobar, un = es para dar valor
        //si pongo !_groundSensor.isGorunded es para verificar si es falso si pone solo _groundSensor.isGorunded es para verificar si es verdadero
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.Translate(new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0));
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);
        
    }
    
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(inputHorizontal * playerSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(new Vector2(inputHorizontal, 0));
        //rigidBody.MovePosition(new Vector2(100, 0));
    }
}
