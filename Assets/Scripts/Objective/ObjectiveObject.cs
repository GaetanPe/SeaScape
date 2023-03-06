using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objective n", menuName= "ScriptableObject/Objective", order =2)]
public class ObjectiveObject : ScriptableObject
{
    public string objectiveName;
    public int goldReward;
    public float beforeEnd;
    public bool isComplete;
    public int requiredCount;
    public int count = 0;
    public EObjectiveType objectiveType = EObjectiveType.None;
    public bool IsComplete()
    {
        if (count >= requiredCount || beforeEnd <=0) 
        {
            isComplete= true;
            count=0;
        }
        return isComplete;
    }


    public enum EObjectiveType 
    {
        None,
        Kill,
        Coins
    }
}
