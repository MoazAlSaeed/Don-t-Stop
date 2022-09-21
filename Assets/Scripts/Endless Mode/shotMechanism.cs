using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotMechanism : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool canShoot;
    public SpriteRenderer firePointColor;

    public float shootRate;
    private void Awake()
    {//it can shoot from the beggining of the scene
        canShoot = true;
        shootRate = 3f;
        firePointColor.color = Color.green;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && Time.timeScale == 1.0f)
        {
            shoot();

            canShoot=false;
            StartCoroutine(shooting());
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("bulletSound");
        firePointColor.color = Color.red;
    }
     
    IEnumerator shooting()
    {//waits for a spesific amount of time
        yield return new WaitForSeconds(shootRate);
        firePointColor.color = Color.green;
        canShoot = true;
    }

    
}
