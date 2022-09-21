using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingProtect : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("damageWall")||other.gameObject.CompareTag("coin"))
        {//the heart has the priority over spikes and coins
          
            Destroy(other.gameObject);
        }
    }
}
