using UnityEngine;

public class DropOffRespawner : MonoBehaviour
{
    public GameObject dropOffPrefab;
    public Transform player;
    public float spawnDistance = 30f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;
        spawnPosition.y = dropOffPrefab.transform.position.y;
        Instantiate(dropOffPrefab, spawnPosition, dropOffPrefab.transform.rotation);
    }
}
