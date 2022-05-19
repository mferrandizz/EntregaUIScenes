using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip HitSFX;
    public AudioClip deathNinja;
    public AudioClip jumpLeeSin;
    public AudioClip botiquinSFX;
    public AudioClip speed;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
   
   public void HitSound()
   {
       _audioSource.PlayOneShot(HitSFX);
   }

   public void DeathNinja()
   {
       _audioSource.PlayOneShot(deathNinja);
   }

   public void JumpSound()
   {
       _audioSource.PlayOneShot(jumpLeeSin);
   }

   public void Curacion()
   {
       _audioSource.PlayOneShot(botiquinSFX);
   }

   public void Speed()
    {
        _audioSource.PlayOneShot(speed);
    }
    
}
