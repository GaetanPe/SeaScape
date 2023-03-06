using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/SpeedBoost Item")]
public class SpeedBoostItem : Item
{
    public float activeTime;
    public float newMaxSpeed;

    private float oldSpeed = 0;
    private float boostStart = 0;

    private event Action boostTime = null;


    void OnEnable()
    {
        boostTime?.Invoke();
    }



    public override void onItemUse()
    {
        Inventory.inventoryInstance.removeItem(this);

        boostTime -= use;
        boostTime += use;

        oldSpeed = GameManager.playerInstance.accessBoatComponent<BoatController>().maxSpeed;
        boostStart = Time.time;

        GameManager.playerInstance.accessBoatComponent<BoatController>().maxSpeed = newMaxSpeed;
    }


    /**
     * Calls item function
     */
    void use()
    {
        if(Time.time >= boostStart + activeTime)
        {
            GameManager.playerInstance.accessBoatComponent<BoatController>().maxSpeed = oldSpeed;
            boostTime -= use;
        } 
    }
}