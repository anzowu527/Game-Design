using UnityEngine;
using TMPro;

public class DeliveryCounterUI : MonoBehaviour
{
    public InventorySystem inventorySystem;
    public TextMeshProUGUI moneyText;
    public int totalDeliveries;

    void Update()
    {
        int completedDeliveries = inventorySystem.completedDeliveries;
        int money = completedDeliveries*5;
        moneyText.text = $"{money}/{totalDeliveries*5}";
    }
}
