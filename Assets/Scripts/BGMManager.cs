using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
   public static BGMManager instance;

   private AudioSource _aduioSource;


   void Awake()
   {
    if(instance != null && instance != this)
    {
        Destroy(gameObject);
    }
    else
    {
        instance = this;
    }

    _aduioSource = GetComponent<AudioSource>();
   }

   public void PlayBGM(AudioClip clip)
   {
    _aduioSource.clip = clip;
    _aduioSource.Play();
   }
}
