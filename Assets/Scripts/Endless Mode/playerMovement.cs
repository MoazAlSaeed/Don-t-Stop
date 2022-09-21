using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
  
    
    
    
    public Rigidbody2D body;
    public float playerSpeed;
    public float playerSpeedLevels;
    Camera cam;
    Transform my;
     float posX;
    public float add;
    float posY;

    public GameObject despawning;

    public GameObject playerBlood;

    public GameObject healingParticles;


    public HealthBar healthBar;
    public int health;
    public int maxHealth;

    public SpriteRenderer render;
    public SpriteRenderer playerColor;
    PlayerData scoresaved;

    public int Score;
    public int highScore;

    public GameObject victoryUI;
    

    public bool endlessMode;
    public void Start()
    {
        
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            endlessMode = true;
            Debug.Log("The endless mode is on!");
        }
        else
        {
            endlessMode = false;
            Debug.Log("No endless mode");
        }
        maxHealth = 20;
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
   
      

        cam = Camera.main;
        posX = 0;
        posY =0;

        if (endlessMode)
        {
            add = 0.13f;
        }
        else { add = 0; }
     
        my = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
     
        playerSpeed = 10;

        StartCoroutine(scoreOverTime());
        Score = 0;
       

        
    }
    private void Update()
    {
        //if it is not endless mode it will attach camera movement to the player
        if (!endlessMode)
        {
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        }
        // if the player acheives new high score, it will update
        if (Score > highScore)
        {
            highScore = Score;
        }
        //this line of code updates the healthbar according to the current player health
        healthBar.setHealth(health);

        //the normal default playerMovement line of Code  
        if (endlessMode)
        {
            body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, Input.GetAxisRaw("Vertical") * playerSpeed);
        }
        if (!endlessMode)
        {
            body.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") *playerSpeedLevels, Input.GetAxisRaw("Vertical") * playerSpeedLevels));
          
        if (Input.GetKey(KeyCode.LeftShift))
        {if(body.velocity.magnitude > 0)
                {
                    body.AddForce(-body.velocity*1f);
                }
            

               
        } 
        }
       

        // Distance from camera to object.  We need this to get the proper calculation.
        float camDis = cam.transform.position.y - my.position.y;

        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - my.position.y, mouse.x - my.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        body.rotation = angle;
       
        // if the player exceeds the max health, this line of code will return the health to the max limit
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }
    private void FixedUpdate()
    { // if the player is in the endless mode, it will move the camera with a constant speed
        if (endlessMode)
        {
            posX += add;
            cam.transform.position = new Vector3(posX, posY, -10);
            despawning.transform.position = new Vector3(posX - 32.4f, posY, 0);
            
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {// the damage that the player would get if he hit the spikes
        if (other.gameObject.CompareTag("damageWall"))
        {
            health-=2;
            FindObjectOfType<AudioManager>().Play("playerHurt");
            Instantiate(playerBlood,transform.position,Quaternion.identity);
            StartCoroutine(damageColor());

        }
       
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("healWall"))
        {//the gaining of the health that the player will get if he collects hearts
            health += 8;
            Instantiate(healingParticles, other.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("healingBlock");
            if (endlessMode)
            {
                FindObjectOfType<spawningRandom>().healWallNUM--;
                FindObjectOfType<spawningRandom>().heartsCollected++;
            }
            Score += 5;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("coin"))
        {//the score will increase if the player collected coins
            Destroy(other.gameObject);
           
            if (endlessMode)
            {
                FindObjectOfType<spawningRandom>().coinsCollected++;
            }
           
            Score += 3;
           

         FindObjectOfType<AudioManager>().Play("coin");
        }
        if (other.gameObject.CompareTag("victoryStar"))
        {
            Destroy (other.gameObject);
          FindObjectOfType<AudioManager>().Play("victoryStar");
            Invoke("victory", 1f);

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerKill"))
        {//if the player exited a spesific area, he will die
            health = 0;
        }
    }

    IEnumerator damageColor()
    {
        render.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        render.color =playerColor.color ;
    }

    IEnumerator scoreOverTime()
    {//the score will increase 10 scorepoints per 30 seconds in the endless mode
        if (endlessMode)
        {
            yield return new WaitForSeconds(30);
            Score += 10;
            FindObjectOfType<AudioManager>().Play("30secPassed");
            StartCoroutine(scoreOverTime());
        }
    }
   void victory()
    {
  
        victoryUI.SetActive(true);
    }

}
