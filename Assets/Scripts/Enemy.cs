using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //variable para controlar la velocidad del Goomba
    public float movementSpeed = 4.5f;
    //variable para saber que direccion se mueve el goomba
    private int directionX = 1;
    
    //variable para almacenar el rigidbody del enemigo
    private Rigidbody2D  rigidBody;

    public bool isAlive = true;

    private GameManager gameManager;
    private BGMManager bgmManager;
    private SFXManager sfxManager;


    void Awake()
    {   
        rigidBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bgmManager = GameObject.Find("GameManager"). GetComponent<BGMManager>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }


    void FixedUpdate()
    {
        if(isAlive)
        {
            //Anade velocidad al eje x
        rigidBody.velocity = new Vector2(directionX * movementSpeed,rigidBody.velocity.y);
        }else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("EndMenu");
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.tag == "Barrera")
        {
            Debug.Log("Collision de Ninja");

            if(directionX == 1)
            {
                directionX = -1;
            }
            else
            {
                directionX = 1;
            }
        }
        else if(hit.gameObject.tag == "MuereNinja")
        {
            Debug.Log("Toma Shuriken");
            sfxManager.HitSound();
            if(gameManager.vida > 0)
            {
                gameManager.vida = gameManager.vida - 20;
                Debug.Log("Tienes "+gameManager.vida+" de vida ");
            }else
            {
                Destroy(hit.gameObject);
                Debug.Log("Has muerto Lee Sin malvado");
                gameManager.HitLS();
            }
        }
    }
}
