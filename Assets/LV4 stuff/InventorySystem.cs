using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private List<string> pizzas = new List<string>();
    public int completedDeliveries = 0;

    public delegate void PizzaPickedUpHandler(int currentPizzaCount);
    public event PizzaPickedUpHandler OnPizzaPickedUp;

    public delegate void DeliveryCompletedHandler(int completedDeliveries);
    public event DeliveryCompletedHandler OnDeliveryCompleted;

    public void AddPizza(string pizzaType)
    {
        pizzas.Add(pizzaType);
        OnPizzaPickedUp?.Invoke(pizzas.Count);
    }

    public bool RemovePizza(string pizzaType)
    {
        bool removed = pizzas.Remove(pizzaType);
        if (removed)
        {
            completedDeliveries++;
            OnDeliveryCompleted?.Invoke(completedDeliveries);
        }
        return removed;
    }

    public int GetPizzaCount(string pizzaType)
    {
        int count = 0;
        foreach (string pizza in pizzas)
        {
            if (pizza == pizzaType) count++;
        }
        return count;
    }

    // Add a public method to get the required pizza type
    public string GetRequiredPizzaType()
    {
        if (pizzas.Count > 0)
        {
            return pizzas[0];
        }
        return null;
    }
}
