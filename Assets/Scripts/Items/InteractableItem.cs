using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : Interactable
{
    public Item item;

    void Update()
    {
        if(Vector3.Distance(GameManager.playerInstance.player.transform.position, this.transform.position) <= radius)
            interact();
    }

    public override void interact()
    {
        Inventory.inventoryInstance.addItem(item);

        Destroy(gameObject);
    }
}