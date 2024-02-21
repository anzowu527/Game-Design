using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    public FuelManager maxFuel;
    public FuelManager Fuel;
    private Image gasbar;

    void Start()
    {
        gasbar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        gasbar.fillAmount = Fuel.fuel/maxFuel.maxFuel;

    }
}
