using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Player Singleton

    // Returns player's and inventory's instances
    public static GameManager playerInstance;

    void Awake()
    {
        playerInstance = this;
    }

    #endregion


    #region Attributes (Player GameObject)

    [Header("\t--- Player")]
    public GameObject player;

    #endregion


    #region Boat Component Accesses

    public Compo accessBoatComponent<Compo>()
    {
        return playerInstance.player.GetComponent<Compo>();
    }
    public Compo accessBoatChildComponent<Compo>()
    {
        return playerInstance.player.GetComponentInChildren<Compo>();
    }

    #endregion
}