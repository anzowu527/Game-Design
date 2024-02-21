using UnityEngine;

public class PizzaDropOff : MonoBehaviour
{
    public string requiredPizzaType = "DefaultPizza";

    private void OnTriggerEnter(Collider other)
    {
        InventorySystem inventory = other.GetComponent<InventorySystem>();
        if (inventory != null)
        {
            if (inventory.RemovePizza(requiredPizzaType))
            {
                // Do any additional actions for successful delivery here
                gameObject.SetActive(false); // Deactivate the drop-off point after successful delivery
            }
        }
    }
}

