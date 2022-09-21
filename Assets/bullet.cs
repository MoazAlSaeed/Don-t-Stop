using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed;
    public Rigidbody2D body;
    public GameObject SpikeExplode;

    public int damage;



    void Start()
    {
        speed = 50f;
        body.velocity = transform.right * speed;
        Invoke("selfKill", 2f);

    }
    void selfKill()
    {//destroying the bullet if it exceeds 2 seconds without touching anything
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!FindObjectOfType<playerMovement>().endlessMode)
        {
            if (other != null)
            {
              
                if (other.gameObject.CompareTag("Enemy"))
                {
                    FindObjectOfType<enemyHealth>().Damage(damage);
                    Destroy(this.gameObject);
                }

                if (other.gameObject.CompareTag("Weapon") || other.gameObject.CompareTag("Arm") || other.gameObject.CompareTag("bulletPointer") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("playerKill") || other.gameObject.CompareTag("Bullet"))
                {
                    return;
                }
                Debug.Log(other.gameObject.tag);
                Destroy(this.gameObject);
            }
        }
      


       /* if (other.gameObject.CompareTag("damageWall"))
        {



            Destroy(this.gameObject);


        }

       
       */

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerKill"))
        {
            Destroy(this.gameObject);
        }
    }

}
