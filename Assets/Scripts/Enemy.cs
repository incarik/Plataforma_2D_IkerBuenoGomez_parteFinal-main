using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int healthPoints = 3;
    private AudioSource _audioSource;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        SoundManager.instance.PlaySFX(_audioSource ,SoundManager.instance.mimikAudio);
    }

    void Update()
    {
        
    }

     public void TakeDamage()
        {
            healthPoints--;
                
            if(healthPoints <= 0)
            {
                Die();
            }
        }
    void Die()
        {
             Destroy(gameObject, 1f);
        }
}
