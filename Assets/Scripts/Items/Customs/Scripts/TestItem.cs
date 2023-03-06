using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/TestItem")]
public class TestItem : Item
{



    /**
     * Calls item function
     */
    override
    public void onItemUse()
    {
        Debug.Log("I used a TestItem");
    }
}