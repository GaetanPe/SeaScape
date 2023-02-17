using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("\t--- Item attributes")]
    new public string name = "Default Item";    // Name of the item
    public Sprite icon = null;              // Item icon
    public bool showInInventory = true;

    /**
     * Calls item function (to be overridden)
     */
    public virtual void use()
    {
        
    }

    /**
     * Removes the item rom the inventory
     */
    public void removeFromInventory()
    {
        Inventory.instance.removeItem(this);
    }
}