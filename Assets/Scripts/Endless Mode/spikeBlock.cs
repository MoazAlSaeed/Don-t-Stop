using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeBlock : MonoBehaviour
{
   
  
    public GameObject spikeExplode;
    public GameObject heart;
  


    

   
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
          
            Destroy(gameObject);
         
            FindObjectOfType<playerMovement>().Score += 2;
            
            FindObjectOfType<AudioManager>().Play("spikeExplosion");
  

            Instantiate(spikeExplode, transform.position, Quaternion.identity);
       
            if (Random.Range(1, 10) == 3)
            {
                Instantiate(heart, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);
        }
    }

}
