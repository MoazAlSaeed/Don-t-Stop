using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody2D rb;
   public float speed;
    public GameObject MissileExplode;
    public GameObject playerBlood;
    private void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        speed = 1f;
        rb.velocity = transform.up * speed;
    }

    private void Update()
    {
       rb.AddForce(rb.velocity);
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null)
        {
            if (other.gameObject.CompareTag("MissileBase"))
                return;
            else
            {

                if (other.gameObject.CompareTag("Player"))
                {
                    FindObjectOfType<playerMovement>().health -= 5;
                }
                if (other.gameObject.CompareTag("damageWall"))
                {
                    Destroy(other.gameObject);
                }
                Instantiate(MissileExplode, this.transform.position, this.transform.rotation);
                FindObjectOfType<AudioManager>().Play("MissileExplode");
                Instantiate(playerBlood, other.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Instantiate(MissileExplode, this.transform.position, this.transform.rotation);
            FindObjectOfType<AudioManager>().Play("MissileExplode");
            Destroy(this.gameObject);
        }
    }
}
