using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [System.Serializable]
    public struct Location
    {
        public Transform locationTransform;
        public Vector3 locationVector3;
        
        public Vector3 Position
        {
            get
            {
                if (locationTransform != null)
                {
                    return locationTransform.position;
                }
                else
                {
                    return locationVector3;
                }
            }
        }
    }
    
    [SerializeField] private GameObject dropOffPrefab;
    [SerializeField] private GameObject pickUpPrefab;
    [SerializeField] private List<Location> presetLocations;
    
    private GameObject currentDropOff;
    private GameObject currentPickUp;
    
    void Start()
    {
        SpawnNewDeliveryPoints();
    }
    
    public void SpawnNewDeliveryPoints()
    {
        // Destroy the previous drop off and pick up points if they exist
        if (currentDropOff != null)
        {
            Destroy(currentDropOff);
        }
        if (currentPickUp != null)
        {
            Destroy(currentPickUp);
        }

        // Get random indices for the preset locations
        int dropOffIndex = Random.Range(0, presetLocations.Count);
        int pickUpIndex = Random.Range(0, presetLocations.Count - 1);
        if (pickUpIndex >= dropOffIndex)
        {
            pickUpIndex++;
        }

        // Instantiate the new drop off and pick up points
        Debug.Log("DeliveryManager: Spawning new delivery points");
        currentDropOff = Instantiate(dropOffPrefab, presetLocations[dropOffIndex].Position, Quaternion.identity);
        currentPickUp = Instantiate(pickUpPrefab, presetLocations[pickUpIndex].Position, Quaternion.identity);
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DropOff"))
        {
            EndDeliverySession();
        }
    }

    public void EndDeliverySession()
    {
        // Your logic for ending the delivery session goes here

        // Spawn new delivery points
        SpawnNewDeliveryPoints();
    }

    public void ClearRemainingPrefabs()
    {
        if (currentDropOff != null)
        {
            Destroy(currentDropOff);
        }
        if (currentPickUp != null)
        {
            Destroy(currentPickUp);
        }
    }
   
}
