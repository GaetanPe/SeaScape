using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region PlayerSingleton

    // Returns player's and inventory's instances
    public static GameManager playerInstance;

    void Awake()
    {
        playerInstance = this;
    }

    #endregion

    [Header("\t--- Player")]
    public GameObject player;
}