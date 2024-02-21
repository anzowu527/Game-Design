using UnityEngine;

public class PizzaPickup : MonoBehaviour
{
    public string pizzaType = "DefaultPizza";

    private void OnTriggerEnter(Collider other)
    {
        InventorySystem inventory = other.GetComponent<InventorySystem>();
        if (inventory != null)
        {
            inventory.AddPizza(pizzaType);
            gameObject.SetActive(false); // Deactivate the pizza object after pickup
        }
    }
}

