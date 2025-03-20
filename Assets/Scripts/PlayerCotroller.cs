using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    //public int direction = 1;
    private float playerSpeed = 4.9f;
    private float inputHorizontal;
    private float jumpForce = 11f;
    private Rigidbody2D rigidBody; //componente del Mario variable de componentes
    private GroundSensor _groundSensor;
    private SpriteRenderer _spriteRendered;
    private Animator _animator;
    private AudioSource _audioSource;
    
    public AudioClip jumpSFX;
    
    
    void Awake() //función de unity 
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
        _spriteRendered = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
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
        
        if(Input.GetButtonDown("Jump") && _groundSensor.isGrounded) //dos == es para comprobar, un = es para dar valor //si pongo !_groundSensor.isGorunded es para verificar si es falso si pone solo _groundSensor.isGorunded es para verificar si es verdadero
        {
            Jump();
        }
        

        Movement();

       _animator.SetBool("IsJumping", !_groundSensor.isGrounded); 
        /*if(_groundSensor.isGrounded)
        {
            _animator.SetBool("IsJumping", false);        
            
        }
        else
        {
            _animator.SetBool("IsJumping", true);  
        }*/

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

    void Movement()
    {
        if(inputHorizontal > 0) //input siempre en el UPDATE
        {
            _spriteRendered.flipX = false;
            _animator.SetBool("IsRunning", true);
        }
        else if(inputHorizontal < 0) //si lo de arriba se cumple no hace falta que compruebes esto
        {
            _spriteRendered.flipX = true;
            _animator.SetBool("IsRunning", true);
        }
        else //si no se cumple ninguna de las condiciones (if y else if) se cumoke el "else"
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _animator.SetBool("IsJumping", true);
        _audioSource.PlayOneShot(jumpSFX);
    }
}

