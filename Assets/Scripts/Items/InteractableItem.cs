using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : Interactable
{
    public Item item;

    public override void interact()
    {
        //Inventory.inventoryInstance.addItem();

        base.interact();

        Inventory.inventoryInstance.addItem(item);

        Destroy(gameObject);
    }



}