using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseB : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public GameObject InfoMenu;
    public Button PauseButton;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
    public void QuitGame()
    {
        print("Quitting");
        Application.Quit();
    }
    private void Update()
    {
        if (InfoMenu.activeSelf) // Use activeSelf instead of SetActive
        {
            PauseButton.interactable = false; 
            Time.timeScale = 0f;

        }
        else
        {
            PauseButton.interactable = true; 
        }

    }
}
