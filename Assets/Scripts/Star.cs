using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private bool interactable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && interactable)
        {
            GameManager.instance.AddStar();

            Destroy(gameObject);

            SoundManager.instance.PlaySFX(SoundManager.instance._audioSource ,SoundManager.instance.coinAudio);
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            interactable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            interactable = false;
        }
    }
}
