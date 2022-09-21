using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upAndDOwn : MonoBehaviour
{
    Rigidbody2D body;
    
   public  float velocity;
    public float duration;
    public Vector2 firstMovement;
    public Vector2 secondMovement;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(moving());
    }
    IEnumerator moving()
    {
        body.velocity = firstMovement*velocity;
        yield return new WaitForSeconds (duration);
        body.velocity = secondMovement*velocity;
        yield return new WaitForSeconds(duration);
        StartCoroutine(moving());
    }
}
