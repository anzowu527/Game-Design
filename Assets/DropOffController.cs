using UnityEngine;

public class DropOffController : MonoBehaviour
{
    private DeliveryManager deliveryManager;
    private InventorySystem inventorySystem;

    public string requiredPizzaType; // Add a public variable for the required pizza type

    void Start()
    {
        deliveryManager = FindObjectOfType<DeliveryManager>();
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int pizzaCount = inventorySystem.GetPizzaCount(requiredPizzaType);

            if (pizzaCount >= 1)
            {
                bool removed = inventorySystem.RemovePizza(requiredPizzaType);
                if (removed)
                {
                    deliveryManager.EndDeliverySession();
                    gameObject.SetActive(false); // Deactivate the current drop off point
                }
            }
        }
    }

    private void OnDisable()
    {
        if (deliveryManager != null)
        {
            deliveryManager.SpawnNewDeliveryPoints();
        }
    }
}
