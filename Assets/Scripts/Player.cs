using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public Transform punyo;
    public float rangeAttack;
    public LayerMask enemylayer;

    public bool isGrounded;

    float dirX;

    public SpriteRenderer renderer;
    public Animator _animator;
    Rigidbody2D _rBody;

    private GameManager gameManager;
    public SFXManager sfxManager;
    

    void Awake()
    {
       _animator = GetComponent<Animator>();
       _rBody = GetComponent<Rigidbody2D>();
       sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    void Update()
    {
       dirX = Input.GetAxisRaw("Horizontal");

       Debug.Log(dirX);

       //transform.position += new Vector3(dirX, 0, 0) * speed * Time.deltaTime;


       if(dirX == -1)
       {
           //renderer.flipX = true;
           transform.rotation = Quaternion.Euler(0,180,0);
           _animator.SetBool("Running", true);
       }
       else if (dirX == 1)
       {
           //renderer.flipX = false;
           transform.rotation = Quaternion.Euler(0,0,0);
           _animator.SetBool("Running", true);
       }
       else
       {
           _animator.SetBool("Running", false);
       }

       if(Input.GetButtonDown("Jump") && isGrounded)
       {
           _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           _animator.SetBool("Jumping", true);
           sfxManager.JumpSound();
       }

       if(Input.GetButtonDown("Fire1") && isGrounded)
       {
           _animator.SetBool("attack", true);
       }

       /*if(Input.GetButtonDown("Fire1") && gameManager.shootPU == true)
       {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

       }*/
    }

    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirX * speed, _rBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            Debug.Log("Ninja muerto");
            gameManager.DeadNinja(collider.gameObject);
            //gameManager.CuentaKillGoomba(collider.gameObject);
        }
        if(collider.gameObject.layer == 7)
        {
            gameManager.CuraBotiquin(collider.gameObject);
        }

        if(collider.gameObject.layer == 8)
        {
            gameManager.GuantesPU(collider.gameObject);
        }

        if(collider.gameObject.layer == 9)
        {
            Debug.Log("Has ganao crack");
            gameManager.VictoriaLee(collider.gameObject);
        }

    }

    


    void Attack()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(punyo.position, rangeAttack, enemylayer);

        foreach(Collider2D enemy in enemys)
        {
            Destroy(enemy.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(punyo.position, rangeAttack);

    }
    
}
