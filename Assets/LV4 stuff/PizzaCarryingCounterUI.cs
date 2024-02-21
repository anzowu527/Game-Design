using UnityEngine;
using TMPro;

public class PizzaCarryingCounterUI : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public TextMeshProUGUI carryingCounterText;

    private void Start()
    {
        inventorySystem.OnPizzaPickedUp += UpdateCarryingCounter;
        inventorySystem.OnDeliveryCompleted += UpdateCarryingCounterAfterDelivery;
        UpdateCarryingCounter(0);
    }

    private void OnDestroy()
    {
        inventorySystem.OnPizzaPickedUp -= UpdateCarryingCounter;
        inventorySystem.OnDeliveryCompleted -= UpdateCarryingCounterAfterDelivery;
    }

    private void UpdateCarryingCounter(int currentPizzaCount)
    {
        carryingCounterText.text = $"Carrying: {currentPizzaCount}";
    }

    private void UpdateCarryingCounterAfterDelivery(int completedDeliveries)
    {
        // Get the required pizza type using the public method from the InventorySystem
        string requiredPizzaType = inventorySystem.GetRequiredPizzaType();
        // Calculate the current pizza count after delivery
        int currentPizzaCount = inventorySystem.GetPizzaCount(requiredPizzaType);
        UpdateCarryingCounter(currentPizzaCount);
    }
}
