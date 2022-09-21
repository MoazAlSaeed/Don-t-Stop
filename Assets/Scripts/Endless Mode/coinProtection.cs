using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinProtection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("damageWall"))
        {// if a spike spawn at the area of a coin, the spike will be destroyed
            Destroy(other.gameObject);
        }
    }
}
