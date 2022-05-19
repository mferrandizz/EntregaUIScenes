using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public Player _player;

    void Awake()
    {
        _player = GameObject.Find("PrincipalCharacterMarc_0").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        _player._animator.SetBool("Jumping", false);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        _player.isGrounded = true;
        //_player._animator.SetBool("Jumping", false);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _player.isGrounded = false;
    }
}

