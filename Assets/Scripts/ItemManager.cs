using UnityEngine;
using System;
using Engine.Utils;

public class ItemManager : Singleton<ItemManager>
{
    #region ItemSingleton
    private event Action itemsUse = null;
    public event Action AitemsUse
    {
        add { itemsUse -= value; itemsUse += value; }
        remove { itemsUse -= value; }
    }

        //public static ItemManager itemManagerInstance;

   /* void Awake()
    {
        itemManagerInstance = this;
    }*/

    #endregion

    protected override void Update()
    {
        base.Update();
        itemsUse?.Invoke();
    }
}