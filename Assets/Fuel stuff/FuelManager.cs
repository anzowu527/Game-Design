using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour
{
    public float fuel;
    public float maxFuel=100f;
    public float fuelConsumptionRate;

    // Start is called before the first frame update
    void Start()
    {
        fuel=100f;
    }

    // Update is called once per frame
    void Update()
    {
    if (fuel <= 0)
        {
            Debug.Log("Out of fuel!");
            return;
        }
    }
}
