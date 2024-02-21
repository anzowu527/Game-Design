using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior1 : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] powerupPrefabs;
    public bool ObstacleOnly=false;
    public bool PowerupOnly=false;
    public static int obstacleSpawned=0;
    public static int powerupSpawned=0;
    

    


public GameObject GetRandomPrefab()
{
    GameObject olimiter = GameObject.Find("SpawnLimiter");
    SpawnLimiter limiter = olimiter.GetComponent<SpawnLimiter>();

    int randomIndex;

    // if we have reached either max we need to spawn the other:
    if(obstacleSpawned>=limiter.maxOb) randomIndex=1;
    else if(powerupSpawned>=limiter.maxPu) randomIndex=0;
    else randomIndex = Random.Range(0, 2); // generates either 0 or 1

    if(PowerupOnly) return powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
    else if(ObstacleOnly) return obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

    if (randomIndex == 0)
    {
        return obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
    }
    else
    {
        return powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
    }
}


    void Start()
    {
        GameObject olimiter = GameObject.Find("SpawnLimiter");
        SpawnLimiter limiter = olimiter.GetComponent<SpawnLimiter>();
        // if both maximums are completed, no more spawning:
        if(obstacleSpawned>=limiter.maxOb&&powerupSpawned>=limiter.maxPu) return;
        if(powerupSpawned>=limiter.maxPu&&PowerupOnly) return;
        if(obstacleSpawned>=limiter.maxOb&&ObstacleOnly) return;
         
        GameObject newObject = Instantiate(GetRandomPrefab(), transform.position, Quaternion.identity);
        Type objectType = newObject.GetComponent<Type>();
        if (objectType.type == "Powerup") powerupSpawned++;
        else if (objectType.type == "Obstacle") obstacleSpawned++;
        }

    }
