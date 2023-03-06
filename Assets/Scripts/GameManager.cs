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



    public Compo accessBoatComponent<Compo>()
    {
        return playerInstance.player.GetComponent<Compo>();
    }
    public Compo accessBoatChildComponent<Compo>()
    {
        return playerInstance.player.GetComponentInChildren<Compo>();
    }
}