using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region ItemSingleton

    public static ItemManager itemManagerInstance;

    void Awake()
    {
        itemManagerInstance = this;
    }

    #endregion

    public GameObject itemManager;

    void Update()
    {
        SpeedBoostItem sbi = (SpeedBoostItem) findItem("SpeedTestItem");
        sbi.onItemUse();
    }




    public Item findItem(string itemName)
    {
        return GameObject.Find(itemName).GetComponent<InteractableItem>().item;
    }
}