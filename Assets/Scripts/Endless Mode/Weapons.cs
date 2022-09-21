using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapons :MonoBehaviour
{//inspecting weapon type
    public bool isShotGun=false;
    public bool isRifle = false;
    public bool isPistol = false;
     public int maxAmmo;
    public int currentAmmo;

    public int damage;

    //three bullet pointers, one when using pistol or rifle, and three when using shotgun
    public GameObject bulletPointer;
    public GameObject bulletPointerTwo;
    public GameObject bulletPointerThree;

    public GameObject bulletPreFab;
    public GameObject shotgunBullet;
    public GameObject RifleBullet;

    public Rigidbody2D playerBody;

    public float reloadTime;
    public float timeBetweenShooting;

    public bool canShoot;
  
    public bool weaponReloading;

    public Transform player;

    PickUpController pickup;

    private void Start()
    {
        currentAmmo = maxAmmo;
        canShoot = true;

        pickup = GetComponent<PickUpController>();
        

    }
    private void Update()
    {


       
          
            //checking if the weapon is reloading right now...........
            if (currentAmmo <= 0)
            {
                weaponReloading = true;
            }
            else { weaponReloading = false; }



        //shooting if the weapon is equipped and canShoot and pressed the left mouse button and there is Ammo
        if (isRifle)
        {
            if (Input.GetMouseButton(0) && canShoot && currentAmmo > 0 && Time.timeScale == 1.0f)
            {
                StartCoroutine(shooting());

            }
        }

        if (isPistol)
        {
            if (Input.GetMouseButtonDown(0) && canShoot && currentAmmo > 0 && Time.timeScale == 1.0f)
            {
                StartCoroutine(shooting());
            }
        }
        if (isShotGun)
        {
            if (Input.GetMouseButtonDown(0) && canShoot && currentAmmo > 0 && Time.timeScale == 1.0f)
            {
                StartCoroutine(shooting());
                Debug.Log(player.rotation.z);
                Debug.Log(-Mathf.Cos(player.rotation.z) + " , "+-Mathf.Sin(player.rotation.z)) ;
               
            
            }
        }
            //if there is no Ammo it will reload
            if (currentAmmo <= 0 &&pickup.equipped)
            {
                StartCoroutine(reloading());
            }
    
        

    }

   IEnumerator shooting()
    {
        
            currentAmmo--;
            canShoot = false;
        if (isRifle)
        {
            Instantiate(RifleBullet, bulletPointer.transform.position, bulletPointer.transform.rotation);

        }
        if (isShotGun)
        {  Instantiate(shotgunBullet, bulletPointer.transform.position, bulletPointer.transform.rotation);
            Instantiate(shotgunBullet, bulletPointerTwo.transform.position, bulletPointerTwo.transform.rotation);
            Instantiate(shotgunBullet, bulletPointerThree.transform.position, bulletPointerThree.transform.rotation);
            if (player.rotation.z > 0.0f&&player.rotation.z<0.5f) { playerBody.AddForce(new Vector2(-Mathf.Abs(Mathf.Cos(player.rotation.z)), -Mathf.Sin(player.rotation.z)) * 500); }
           else if(player.rotation.z > -0.5f && player.rotation.z < 0.0f) { playerBody.AddForce(new Vector2(-Mathf.Abs(Mathf.Cos(player.rotation.z)),- Mathf.Sin(player.rotation.z)) * 500); }
            else if (player.rotation.z > -1.0f && player.rotation.z < 0.0f) { playerBody.AddForce(new Vector2(Mathf.Abs(Mathf.Cos(player.rotation.z)), -Mathf.Sin(player.rotation.z)) * 500); }
            else { playerBody.AddForce(new Vector2(Mathf.Abs(-Mathf.Cos(player.rotation.z)), -Mathf.Sin(player.rotation.z)) * 500); }
        }
        if(isPistol)
        {
            Instantiate(bulletPreFab, bulletPointer.transform.position, bulletPointer.transform.rotation);
        }
            FindObjectOfType<AudioManager>().Play("bulletSound");
            yield return new WaitForSeconds(timeBetweenShooting);
            canShoot = true;
       

    }

 IEnumerator reloading()
    {
        Debug.Log("reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;

    }

  



}
