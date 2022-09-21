using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierCode : MonoBehaviour
{
    public SpriteRenderer render;
    public GameObject player;
  //checks whether the player is touching the barrier or not
    public bool touchBarrier;
    private void Start()
    {// at the beginning of the endless mode scene, the player isn't touching th barrier
        touchBarrier = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {// if the player touches the barrier, the barrier will appear and the player will start taking damage
            render.enabled = true;
            touchBarrier = true;
            StartCoroutine(damage());
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //it guarantees that the barrier will still visible but only if the player is touching it
            render.enabled = true;
           
           
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //when the player stop colliding with the barrier, the barrier wil disappear and the player will no longer take damage
            render.enabled = false;
            touchBarrier=false;
            StopCoroutine(damage());
          
        }
    }


    IEnumerator damage()
    {
        if (touchBarrier)
        {// the player will take damage every 2 seconds
            yield return new WaitForSeconds(2f);
            if (touchBarrier)
            {
                FindObjectOfType<playerMovement>().health--;
                Instantiate(FindObjectOfType<playerMovement>().playerBlood, player.transform.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("playerHurt");
                StartCoroutine(damage());
            }
        }
    }

}
