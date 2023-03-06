using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;
using System;
using System.Linq.Expressions;
using TMPro;

public class ObjectiveManager : Singleton<ObjectiveManager>
{
    [SerializeField] private List<ObjectiveObject> objectiveObjects= new List<ObjectiveObject>();
    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private ObjectiveObject currentObjective;

    protected override void Start()
    {
        // Choose a random objective to start with
        currentObjective = GetCurrentObjective();

        // Update the UI to display the current objective
        objectiveText.text = "Objective: " + currentObjective.objectiveName + "\n" + currentObjective.count + "/" + currentObjective.requiredCount;
    
    }

    protected override void LateUpdate()
    {
        if (currentObjective.IsComplete())
        {
            UpdateObjective(currentObjective);
            currentObjective.isComplete = false;
            currentObjective = GetCurrentObjective();
            UpdateObjectiveUI();
        }
    }

    void AddObjective(ObjectiveObject objective)
    { 
        objectiveObjects.Add(objective);
    }

    void UpdateObjective(ObjectiveObject objective)
    {

        objective.requiredCount = (int)UnityEngine.Random.Range(1, 10);
        objective.beforeEnd = (int)UnityEngine.Random.Range(60, 180);
    }

    void UpdateObjectiveUI()
    {
        objectiveText.text = "Objective: " + currentObjective.objectiveName + "\n" + currentObjective.count +"/" + currentObjective.requiredCount;
    }

    ObjectiveObject GetCurrentObjective()
    {
        int randomIndex = UnityEngine.Random.Range(0, objectiveObjects.Count);

        return objectiveObjects[randomIndex];
    }


}
