using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region Attributes

    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    #endregion


    #region Start/Update

    void Start()
    {
        inventory = Inventory.inventoryInstance;
        inventory.onItemChangedCallback += updateUI;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) // Input.GetButtonDown("Inventory") doesn't work form some reason
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            updateUI();
        }
    }

    #endregion


    #region Update UI

    void updateUI()
    {
        InventorySlot[] slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        for (int i = 0 ; i< slots.Length ; i++)
        {
            if(i < inventory.inventoryItems.Count)
                slots[i].addItem(inventory.inventoryItems[i]);
            else
                slots[i].clearSlot();
        }
    }

    #endregion
}
