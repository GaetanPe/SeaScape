using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory inventoryInstance;

    void Awake()
    {
        inventoryInstance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space;

    [Header("\t--- Inventory items")]
    public List<Item> inventoryItems = new List<Item>();

    /**
     * Adds the item in the inventory if there is enough room
     */
    public void addItem(Item item)
    {
        if(item.showInInventory)
        {
            if(inventoryItems.Count >= space)
            {
                Debug.Log("Not enough room.");
                return;
            }

            inventoryItems.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    /**
     * Removes the item from the inventory
     */
    public void removeItem(Item item)
    {
        inventoryItems.Remove(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}