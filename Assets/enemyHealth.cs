using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
   

    private void Start()
    {
        health = maxHealth;
        

    }
    private void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);

        }
    }

  
  public void Damage(int ouch)
    {
        health -= ouch; 
    }

}
