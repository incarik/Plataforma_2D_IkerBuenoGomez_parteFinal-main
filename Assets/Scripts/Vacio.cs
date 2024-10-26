using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacio : MonoBehaviour
{
    [SerializeField] private int healthPoints = 3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
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
