using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDestroy : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("damageWall"))
        {//destroying the object if it gets out of the camera frame
            Destroy(other.gameObject);
            
            FindObjectOfType<spawningRandom>().damageWallNum--;
          
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {//destroying the object if it gets out of the camera frame
            Destroy(other.gameObject);
            FindObjectOfType<spawningRandom>().coinNum--;
        }
        if (other.gameObject.CompareTag("healWall"))
        {//destroying the object if it gets out of the camera frame
            Destroy(other.gameObject);
            FindObjectOfType<spawningRandom>().healWallNUM--;
        }
    }
}
