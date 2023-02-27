using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("\t--- Item attributes")]
    new public string name = "Default Item";
    public Sprite icon = null;
    public bool showInInventory = true;

    /**
     * Calls item function (to be overridden)
     */
    public virtual void use()
    {
        
    }

    /**
     * Removes the item from the inventory
     */
    public void removeFromInventory()
    {
        Inventory.instance.removeItem(this);
    }
}