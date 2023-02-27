using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;
using System;

public class ObjectiveSystem : Singleton<ObjectiveSystem>
{
    [SerializeField] private List<ObjectiveObject> objectiveObejects= new List<ObjectiveObject>();
    System.Random randomObjective = new System.Random();
    int nbrRandom = 0;

    void currentObjective()
    {
        nbrRandom = randomObjective.Next(objectiveObejects.Count);

    }

   

}
