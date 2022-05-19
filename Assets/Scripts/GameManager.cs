using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SFXManager sfxManager;
    private GameManager gameManager;
    private BGMManager bgmManager;
    public float vida = 100f;
    private Player player;



     void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    public void HitLS()
    {
        bgmManager.StopBGM();
        Invoke("LoadMainMenu", 3);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("EndMenu");
    }

    public void CuraBotiquin(GameObject botiquin)
    {
        Destroy(botiquin);
        sfxManager.Curacion();
        gameManager.vida = gameManager.vida + 40;
        Debug.Log("Te has curado 40 de vida ahora tienes "+gameManager.vida);
    }

    public void GuantesPU(GameObject guantes)
    {
        Destroy(guantes);
        sfxManager.Speed();
        player.speed = 30f;
        Debug.Log("Corre corre correeeee");
    }

    public void VictoriaLee(GameObject ninja)
    {
        //Variable para el animator,script y colliuder del goomba
        Animator ninjaAnimator;
        Enemy ninjaScript;
        BoxCollider2D ninjaCollider;
        //Assignamos las variable
        ninjaScript = ninja.GetComponent<Enemy>();
        ninjaAnimator = ninja.GetComponent<Animator>();
        ninjaCollider = ninja.GetComponent<BoxCollider2D>();

        //cambiamos a la animacion de muerte
        //ninjaAnimator.SetBool("GoombaMuerte", true);
        
        ninjaScript.isAlive = false;

        //goombaCollider.size = new Vector2(1, 0.5f);
        //goombaCollider.offset = new Vector2(0, 0.25f);

        ninjaCollider.enabled = false;

        Destroy(ninja, 0.3f);
        
        /*killsGoomba = killsGoomba+1;
        Debug.Log("Has asesinado un total de "+killsGoomba+" Goomba/s");
        goombaText.text = "DeadGoombas: " + killsGoomba;

        if(killsGoomba == 5)
        {
            sfxManager.PentaGoombas();
        }*/

        sfxManager.DeathNinja();
        
        bgmManager.StopBGM();
        Invoke("LoadMainMenu", 3);

    }

    //Funcion para matar al Ninja
    public void DeadNinja(GameObject ninja) 
    {
        //Variable para el animator,script y colliuder del goomba
        Animator ninjaAnimator;
        Enemy ninjaScript;
        BoxCollider2D ninjaCollider;
        //Assignamos las variable
        ninjaScript = ninja.GetComponent<Enemy>();
        ninjaAnimator = ninja.GetComponent<Animator>();
        ninjaCollider = ninja.GetComponent<BoxCollider2D>();

        //cambiamos a la animacion de muerte
        //ninjaAnimator.SetBool("GoombaMuerte", true);
        
        ninjaScript.isAlive = false;

        //goombaCollider.size = new Vector2(1, 0.5f);
        //goombaCollider.offset = new Vector2(0, 0.25f);

        ninjaCollider.enabled = false;

        Destroy(ninja, 0.3f);
        
        /*killsGoomba = killsGoomba+1;
        Debug.Log("Has asesinado un total de "+killsGoomba+" Goomba/s");
        goombaText.text = "DeadGoombas: " + killsGoomba;

        if(killsGoomba == 5)
        {
            sfxManager.PentaGoombas();
        }*/

        sfxManager.DeathNinja();

    }
}
