using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
  public static bool GameisPaused = false;
    public GameObject pauseMenuUI;

    public GameObject BarrierAlert;

    public playerMovement playerMove;
    bool endRun;
    private void Start()
    {
        playerMove = GetComponent<playerMovement>();
        endRun = playerMove.endlessMode;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }

        //alerts you that you are touching the barrier in the endless mode
        if (Time.timeScale != 0&&endRun)
        {
            
                if (FindObjectOfType<barrierCode>().touchBarrier)
                {
                    BarrierAlert.SetActive(true);
                }
                else
                {
                    BarrierAlert.SetActive(false);
                }
            
        }
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        FindObjectOfType<playTime>().playing = true;
        Time.timeScale = 1.0f;
        GameisPaused = false;
    }
    private void pause()
    {
        pauseMenuUI.SetActive(true);
        FindObjectOfType<playTime>().playing = false;
        Time.timeScale = 0f;
        GameisPaused = true;

    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        Debug.Log("HE");
        
        SceneManager.LoadScene(0,LoadSceneMode.Single);
        FindObjectOfType<PickUpController>().Drop();
    }
    public void retry()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
    public void nextLevel()
    {
        Time.timeScale = 1f;
        if (!FindObjectOfType<playerMovement>().endlessMode) FindObjectOfType<PickUpController>().Drop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
