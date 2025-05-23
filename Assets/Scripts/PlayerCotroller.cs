using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCotroller : MonoBehaviour
{
    //public int direction = 1;
   
    private float playerSpeed = 4.9f;
    private float inputHorizontal;
    private float jumpForce = 13f; 
    [Header("Hola")]
    public float powerUpDuration = 10f;
    public float powerUpTimer;

    [Header("Adios")]
    public float delay = 3f;
    private float gameOverDelay = 3f;

    [SerializeField] private float _dashForce = 20;
    [SerializeField] private float _dashDuration = 0.5f;
    [SerializeField] private float _dashCoolDown = 1f;


    private bool _canDash = true;
    private bool _isDashing = false;

    [SerializeField] private float _attackDamage = 10;
    
    [SerializeField] private float _attackRadius = 1; 
    [SerializeField] private Transform _hitBoxPosition;

    [SerializeField] private float _basedChargedAttackDamage = 15;
    [SerializeField] private float _maxChargedAttackDamage = 40;
    [SerializeField] private LayerMask _enemyLayer;

    private float _chargedAttackDamage;
    
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public bool canShoot = false;
    

    private Rigidbody2D rigidBody; //componente del Mario variable de componentes
    
    private GroundSensor _groundSensor;

    private SpriteRenderer _spriteRendered;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    private GameManager _gameManager;
    private SoundManager _soundManager;
    public Image powerUpImage;
    
    private AudioSource _audioSource;
    public AudioClip jumpSFX;
    public AudioClip deathSFX;
    public AudioClip shootSFX;
    public AudioClip _gameOverSFX;




    void Awake() //función de unity 
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
        _spriteRendered = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

        _chargedAttackDamage = _basedChargedAttackDamage;
        //Esto teletransporta al personaje
        //transform.position = new Vector3 (-108.75f,-5.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!_gameManager.isPlaying || _soundManager.isGameOver)
        {
            return;
        }
        if(_gameManager._isPaused)
        {
            return;
        }

        if(_isDashing)
        {
            return;
        }

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetButtonDown("Jump")) //dos == es para comprobar, un = es para dar valor //si pongo !_groundSensor.isGorunded es para verificar si es falso si pone solo _groundSensor.isGorunded es para verificar si es verdadero
        {
            if(_groundSensor.isGrounded || _groundSensor.canDoubleJump)
            {
                Jump();
            }
            
        }
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            StartCoroutine(Dash());
        }

        if(Input.GetButtonDown("Fire2"))
        {
            NormalAttack();
        }

        /*if(Input.GetButtonDown("Fire2"))
        {
            AttackCharge();
        }

        if(Input.GetButtonUp("Fire2"))
        {
            ChargedAttack(); 
        }*/


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

        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }


        if(canShoot)
        {
            PowerUp();
        }
        


    }
    
    void FixedUpdate()
    {
        if(_isDashing)
        {
            return;
        }
        rigidBody.velocity = new Vector2(inputHorizontal * playerSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(new Vector2(inputHorizontal, 0));
        //rigidBody.MovePosition(new Vector2(100, 0));
        
    }

    void Movement()
    {
        if(inputHorizontal > 0) //input siempre en el UPDATE
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if(inputHorizontal < 0) //si lo de arriba se cumple no hace falta que compruebes esto
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else //si no se cumple ninguna de las condiciones (if y else if) se cumoke el "else"
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {

        if(!_groundSensor.isGrounded)
        {
            _groundSensor.canDoubleJump = false;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);

        }
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _animator.SetBool("IsJumping", true);
        //_audioSource.volume = 0.5f;
        _audioSource.PlayOneShot(jumpSFX);
    }

    public void Death()
    {
        _animator.SetTrigger("IsDead");
        _audioSource.PlayOneShot(deathSFX);
        _boxCollider2D.enabled = false;
        //rigidBody.gravityScale = 0;

        Destroy(_groundSensor.gameObject);
        
        inputHorizontal = 0;
        rigidBody.velocity = Vector2.zero;
        
        rigidBody.AddForce(Vector2.up * jumpForce/1.5f, ForceMode2D.Impulse);
        
        StartCoroutine(_soundManager.DeathBGM());
        
        //_soundManager.Invoke("DeathBGM", deathSFX.lenght);

        _gameManager.isPlaying = false;
        StartCoroutine(GameOverScene());

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        _audioSource.PlayOneShot(shootSFX);
    }

    void PowerUp()
    {
        powerUpTimer += Time.deltaTime;
        powerUpImage.fillAmount = Mathf.InverseLerp(powerUpDuration, 0, powerUpTimer);
        if(powerUpTimer >= powerUpDuration)
        {
            canShoot = false;
            powerUpTimer = 0;
        }
    }

    public void GameOverUI()
    {
        //_boxCollider2D.enabled = false;
        _soundManager.isGameOver = true;
        _soundManager.PauseBGM(); 
        StartCoroutine(GameOverScene());
        
        
        
    }

    public IEnumerator GameOverScene()
    {
        //Destroy(_groundSensor.gameObject);
        _audioSource.PlayOneShot(deathSFX);
        yield return new WaitForSeconds(delay);
        _audioSource.PlayOneShot(_gameOverSFX);
        yield return new WaitForSeconds(gameOverDelay);
        Destroy(gameObject);
        SceneManager.LoadScene(2);
    }

    IEnumerator Dash()
    {
        float gravity = rigidBody.gravityScale;
        rigidBody.gravityScale = 0;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x ,0); 
        
        
        _isDashing = true;
        _canDash = false;
        rigidBody.AddForce(transform.right*_dashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_dashDuration);
        rigidBody.gravityScale = gravity;
        _isDashing = false;
        yield return new WaitForSeconds(_dashCoolDown);
        _canDash = true;
    }
    

    void NormalAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_hitBoxPosition.position, _attackRadius,_enemyLayer);
        foreach(Collider2D enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.TakeDamage(_attackDamage);
        }
    }

    void AttackCharge()
    {
        if(_chargedAttackDamage < _maxChargedAttackDamage)
        {
            _chargedAttackDamage += Time.deltaTime;
            
        }
        else
        {
            _chargedAttackDamage = _maxChargedAttackDamage;
        }

    }

    void ChargedAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_hitBoxPosition.position, _attackRadius, _enemyLayer);
        foreach(Collider2D enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.TakeDamage(_chargedAttackDamage);
        }

        _chargedAttackDamage = _basedChargedAttackDamage;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;


        Gizmos.DrawWireSphere(_hitBoxPosition.position, _attackRadius);
    }






}

