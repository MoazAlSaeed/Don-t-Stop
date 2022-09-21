using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{

    public Rigidbody2D rb;
    public PolygonCollider2D coll;
    public Transform player, gunContainer, fpsCam;
    public SpriteRenderer render;
   public Weapons weapon;
    

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
    

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
     weapon = GetComponent<Weapons>();

        //Setup
        if (!equipped)
        {
            GetComponent<Weapons>().enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            GetComponent <Weapons> ().enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
            Debug.Log(slotFull);

        }
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - this.transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        //Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();



        //fliping the gun if the player rotates.....................................
        if (equipped && ((player.rotation.z > 0.5f && player.rotation.z < 1f) || (player.rotation.z > -1f && player.rotation.z < -0.5f)))
        {
            render.transform.localScale = new Vector3(1, -1, 1);

        }

        //fliping the gun if the player rotates.....................................
        else if (equipped && !((player.rotation.z > 0.5f && player.rotation.z < 1f) || (player.rotation.z > -1f && player.rotation.z < -0.5f)))
        {
            render.transform.localScale = new Vector3(1, 1, 1);

        }



    }

    private void PickUp()
    {
        GetComponent<Weapons>().enabled = true;
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);


        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
        Debug.Log("PIcked UP");
        //Enable script

    }

    public void Drop()
    {
        GetComponent<Weapons>().enabled = false;
        equipped = false;
        slotFull = false;
        
        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of player
 

        //AddForce
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode2D.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode2D.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(random);

        //Disable script

        Debug.Log("Dropped Down");


    }
}
