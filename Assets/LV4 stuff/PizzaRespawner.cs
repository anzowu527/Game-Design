using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaRespawner : MonoBehaviour
{
    public GameObject pizzaPrefab;
    public Transform player;
    public float spawnDistance = 30f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;
        spawnPosition.y = pizzaPrefab.transform.position.y;
        Instantiate(pizzaPrefab, spawnPosition, pizzaPrefab.transform.rotation);
    }
}
