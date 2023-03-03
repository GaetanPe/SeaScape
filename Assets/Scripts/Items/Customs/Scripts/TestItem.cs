using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/TestItem")]
public class TestItem : Item
{



    /**
     * Calls item function
     */
    override
    public void use()
    {
        Debug.Log("I picked up a TestItem");
    }
}
