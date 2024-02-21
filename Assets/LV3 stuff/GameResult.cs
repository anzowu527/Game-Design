using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public static GameResult Instance;

    public CountdownTimer countdownTimer;
    public InventorySystem  inventorySystem;
    public FuelManager Fuel;

    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject FLosePanel;
    public DeliveryManager deliveryManager;
    public UnityEngine.UI.Text text;
    public int TargetCount;
    private bool IsOver;

    GameObject[] spawners;

    public void Start(){
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    public void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        Check();
    }
    public void Check()
    {
        if (IsOver) return;
        if (inventorySystem.completedDeliveries >= TargetCount && countdownTimer.RemainingTime >= 0)
        {
            IsOver = true;
            OnWin();
        }
        else
        {
            if (countdownTimer.RemainingTime < 0)
            {
                IsOver = true;
                OnLose();
            }
            if (Fuel.fuel <= 0)
            {
                IsOver = true;
                FOnLose();
            }
        }
    }

    // Spawn reset stuff:
    public void resetSpawn(){
        foreach(GameObject go in spawners){
            go.BroadcastMessage("Reset");
        }
    }

    public int NextSceneIndex;
    public int HomeSceneIndex;
    public void Next()
    {
        Time.timeScale = 1f;
        resetSpawn();
        UnityEngine.SceneManagement.SceneManager.LoadScene(NextSceneIndex);
    }
    public void Home()
    {
        Time.timeScale = 1f;
        ClearAndStopDeliveries();
        resetSpawn();
        UnityEngine.SceneManagement.SceneManager.LoadScene(HomeSceneIndex);
    }
    public void ReStart()
    {
        Time.timeScale = 1f;
        ClearAndStopDeliveries();
        resetSpawn();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void OnWin()
    {
        text.text = $"Congratulations! You have successfully completed your delivery mission. Your dedication and skill have earned you the title of a top-notch delivery driver. \n\nThere are { countdownTimer.RemainingTime} Seconds left, You finished {inventorySystem.completedDeliveries} deliveries";
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
        ClearAndStopDeliveries();
         
    }
    public void OnLose()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0f;
        ClearAndStopDeliveries();
        

    }
    public void FOnLose()
    {
        FLosePanel.SetActive(true);
        Time.timeScale = 0f;
        ClearAndStopDeliveries();

    }
    public void ClearAndStopDeliveries() 
    { 
        deliveryManager.ClearRemainingPrefabs(); 
    }
    
}
