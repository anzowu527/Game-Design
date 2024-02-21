using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Add this line to use the Button component


public class InfoB : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject InfoMenu;
    public GameObject PauseMenu;
    public Button InfoButton;
    
    public void Info()
    {
        InfoMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Close()
    {
        InfoMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (PauseMenu.activeSelf) // Use activeSelf instead of SetActive
        {
            InfoButton.interactable = false; // Disable the Info Button
        }
        else
        {
            InfoButton.interactable = true; // Enable the Info Button
        }
    }
    
}
