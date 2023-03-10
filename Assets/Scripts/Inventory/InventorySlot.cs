using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    #region Attributes

    [Header("\t--- Image icon")]
    public Image icon;
    public Button deleteButton;

    [Header("\t--- Item")]
    Item item;

    #endregion


    #region Adding/Clearing/Using Slot

    public void addItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        deleteButton.interactable = true;
    }

    public void clearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        deleteButton.interactable = false;
    }

    public void onDeleteButtonPressed()
    {
        Inventory.inventoryInstance.removeItem(item);
    }

    public void useItem()
    {
        if (item != null)
            item.onItemUse();
    }

    #endregion
}