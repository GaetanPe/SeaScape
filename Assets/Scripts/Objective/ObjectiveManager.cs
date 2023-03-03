using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;
using System;
using System.Linq.Expressions;

public class ObjectiveManager : Singleton<ObjectiveManager>
{
    [SerializeField] private List<ObjectiveObject> objectiveObjects= new List<ObjectiveObject>();
    
    void AddObjective(ObjectiveObject objective)
    { 
        objectiveObjects.Add(objective);
    }

    void UpdateObjective(ObjectiveObject objective, string name, int goldReward ,float beforeEnd, bool isComplete)
    {
        objective.objectiveName = name;
        objective.goldReward = goldReward;
        objective.beforeEnd = beforeEnd;
        objective.isComplete = isComplete;
    }

    public string GetCurrentObjective()
    {
        int randomIndex = UnityEngine.Random.Range(0, objectiveObjects.Count);

        return objectiveObjects[randomIndex].objectiveName;
    }


}
