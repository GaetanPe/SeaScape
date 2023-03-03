using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region PlayerSingleton

    // Returnns player's and inventory's instances
    public static GameManager playerInstance;

    void Awake()
    {
        playerInstance = this;
    }

    #endregion

    [Header("\t--- Instances")]
    public GameObject player;







}
