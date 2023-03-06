
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/SpeedBoost Item")]
public class SpeedBoostItem : Item
{
    #region Attributes

    public float activeTime;
    public float newMaxSpeed;

    private float oldSpeed = 0;
    private float boostStart = 0;

    #endregion

    #region Item use

    public override void onItemUse()
    {
        Inventory.inventoryInstance.removeItem(this);

        ItemManager.Instance.AitemsUse+= use;

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
            ItemManager.Instance.AitemsUse -= use;
        } 
    }

    #endregion
}