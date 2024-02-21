using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillGas : MonoBehaviour
{
    public float refillRate = 1.0f;  // how quickly to refill the fuel
    private bool isPlayerInContact = false;
    private FuelManager fuelManager;

    void Start()
    {
        fuelManager = GameObject.Find("FuelManager").GetComponent<FuelManager>();
    }

    void FixedUpdate()
    {
        if (isPlayerInContact)
        {
            fuelManager.fuel = Mathf.Clamp(fuelManager.fuel + refillRate * Time.deltaTime, 0.0f, fuelManager.maxFuel);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInContact = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInContact = false;
        }
    }
}
