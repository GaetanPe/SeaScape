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
}
