using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex=0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
   
    public void endlessRun()
    {
        SceneManager.LoadScene(1);
    }
   

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void lvl1()
    {
       
        SceneManager.LoadScene(2);
    }
    public void lvl2()
    {
        SceneManager.LoadScene(3);
    }
    public void lvl3()
    {
        SceneManager.LoadScene(4);
    }
    public void lvl4()
    {
        SceneManager.LoadScene(5);
    }
    public void lvl5()
    {
        SceneManager.LoadScene(6);
    }
    public void lvl6()
    {
        SceneManager.LoadScene(7);
    }
    public void lvl7()
    {
        SceneManager.LoadScene(8);
    }
    public void lvl8()
    {
        SceneManager.LoadScene(9);
    }
}
