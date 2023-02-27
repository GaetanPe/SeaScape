using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/VolcaronaItem")]
public class VolcaronaItem : Item
{



    /**
     * Calls item function
     */
    override
    public void use()
    {
        Debug.Log("I clicked on Volcarona");
    }
}
