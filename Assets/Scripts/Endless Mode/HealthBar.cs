using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public GameObject player;
    
    public GameObject retryMenuUi;
    public GameObject healthBarRemove;
    public GameObject audioManager;
    public GameObject scoreWhilePlaying;
    public GameObject scoreAfterDeath;

    public GameObject time;
    public GameObject timeAfterDeath;


    playerMovement playerMove;
   
    public void setMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }
    
    
    
    public void setHealth(int health)
    { 
    healthBar.value = health;
    
    }
    public void Update()
    {
        if(healthBar.value <= 0)
        { 
            Destroy(player);
 
            StartCoroutine(theFinal());

        }
    }
IEnumerator theFinal(){
       
       
        FindObjectOfType<playTime>().playing = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(audioManager);
        yield return new WaitForSeconds(2); 
        scoreAfterDeath.SetActive(true);
        scoreWhilePlaying.SetActive(false);
        time.SetActive(false);
        timeAfterDeath.SetActive(true) ;
        retryMenuUi.SetActive(true);   
        healthBarRemove.SetActive(false);
     
       
      
    }

    
}

