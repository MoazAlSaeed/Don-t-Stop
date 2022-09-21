using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningRandom : MonoBehaviour
{//coordinates of the spawned spike
    int damageposX;
    float damageposY;
    //coordinates of the spawned Heart
    int healposX;
    float healposY;
    //coordinates of the spawned Coin
    int coinposX;
    float coinposY;
   
    Vector3 damagepos;
    Vector3 healpos;
    Vector3 coinpos;
    

    public GameObject damageWall;
    public GameObject healWall;
    public GameObject coin;
    public GameObject player;

    //the current number in the scene of each element
    public int damageWallNum;
    public int healWallNUM;
    public int coinNum;

    //the seconds needed to spawn each of the elements
    float damageSpawnRate;
    float healSpawnRate;
    float coinSpawnRate;

    //the  number in the scene of each element from the beginning of the scene
    public int lifetimeDamageWallNUm;
   public int liftimeHealWallNum;
    public int lifetimecoinNum;

    //the coins and hearts collected from the beginning of the scene
    public int coinsCollected;
    public int heartsCollected;



   
    private void Awake()
    {
        coinsCollected = heartsCollected = 0;
       
       

        damageSpawnRate = 0.2f;
        healSpawnRate = 20f;
        coinSpawnRate = 14f;
        healpos=damagepos=coinpos = new Vector3(100, 100, 0);
        damageWallNum = -1;
      healWallNUM=-1;
        coinNum=-1;
        lifetimeDamageWallNUm=0;
        liftimeHealWallNum=-1;
        lifetimecoinNum=-1;
        //this makes the random spawning system only work in endless mode
       
            StartCoroutine(damageWalls());
            StartCoroutine(healWalls());
            StartCoroutine(Coin());
        
    }
    private void Update()
    {

       

            // after one minute in the endless run, it will get harder
            if (Time.timeSinceLevelLoad >60&& Time.timeSinceLevelLoad<60.1f&&FindObjectOfType<playerMovement>().endlessMode)
        {
            damageSpawnRate = 0.16f;
            healSpawnRate = 18f;
            FindObjectOfType<shotMechanism>().shootRate = 1f;
            FindObjectOfType<playerMovement>().add = 0.16f;

            Debug.Log(damageSpawnRate);
        }
        //after three minutes of the endless run, it will be even harder
        if (Time.timeSinceLevelLoad > 180.0 && Time.timeSinceLevelLoad < 180.1f && FindObjectOfType<playerMovement>().endlessMode)
        {
            damageSpawnRate = 0.1f;
            healSpawnRate = 20f;
            FindObjectOfType<playerMovement>().add = 0.16f;

            Debug.Log(damageSpawnRate);
        }
    }
    private void FixedUpdate()
    {
       // the random spawning range

        damageposX = Random.Range(15, 15);
        damageposY = Random.Range(-4.4f, 4.4f);
        damagepos = new Vector3(damageposX, damageposY, 0);

        healposX = Random.Range(15, 15);
        healposY = Random.Range(-4.4f, 4.4f);
        healpos = new Vector3(healposX, healposY, 0);

        coinposX = Random.Range(15, 15);
        coinposY = Random.Range(-4.4f, 4.4f);
        coinpos = new Vector3(coinposX, coinposY, 0);


       



    }


    IEnumerator damageWalls()
    {
        
            //Debug.Log("X is: " + posX);
            //Debug.Log("Y is: " + posY);
            Instantiate(damageWall, transform.position + damagepos, Quaternion.identity);
            damageWallNum++;
            lifetimeDamageWallNUm++;
            yield return new WaitForSeconds(damageSpawnRate);
            StartCoroutine(damageWalls());
        if(player==null)
        {
            StopAllCoroutines();
        }

    }
    IEnumerator healWalls()
    {
        
        
            Instantiate(healWall, transform.position + healpos, Quaternion.identity);
            healWallNUM++;
            liftimeHealWallNum++;
            yield return new WaitForSeconds(healSpawnRate);
            StartCoroutine(healWalls());
        if (player == null)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator Coin()
    {
        
            Instantiate(coin, transform.position + coinpos, Quaternion.identity);
            coinNum++;
            lifetimecoinNum++;
            yield return new WaitForSeconds(coinSpawnRate);
            StartCoroutine(Coin());
        if (player == null)
        {
            StopAllCoroutines();
        }

    }
    
    
}
