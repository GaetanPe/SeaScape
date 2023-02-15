using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objective n", menuName= "ScriptableObject/Objective", order =2)]
public class ObjectiveObeject : ScriptableObject
{
    [SerializeField] private string objectiveName;
    [SerializeField] private int goldReward;
    [SerializeField] private float beforeEnd;

}
