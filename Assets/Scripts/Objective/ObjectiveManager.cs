using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;
using System;
using System.Linq.Expressions;
using TMPro;
using System.Diagnostics;
using System.Threading;

public class ObjectiveManager : Singleton<ObjectiveManager>
{
    [SerializeField] private List<ObjectiveObject> objectiveObjects= new List<ObjectiveObject>();
    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private ObjectiveObject currentObjective;
    [SerializeField] private float timer;

    protected override void Start()
    {
        // Choose a random objective to start with
        currentObjective = GetCurrentObjective();

        // Update the UI to display the current objective
        objectiveText.text = "Objective: " + currentObjective.objectiveName + "\n" + currentObjective.count + "/" + currentObjective.requiredCount + "\n" + "remaining times: " + currentObjective.beforeEnd;
        timer = currentObjective.beforeEnd;
        InvokeRepeating("DecrementTimer", 0, 1f);//used to called the function decrement every 0,2 seconds

    }

    protected override void LateUpdate()
    {
        if (currentObjective.IsComplete())
        {
            UpdateObjective(currentObjective);
            currentObjective.isComplete = false;
            currentObjective = GetCurrentObjective();
            timer = currentObjective.beforeEnd;
            UpdateObjectiveUI();
        }
        else if(timer<= 0)
        {
            UpdateObjective(currentObjective);
            currentObjective = GetCurrentObjective();
            timer = currentObjective.beforeEnd;
            UpdateObjectiveUI();
        }
        objectiveText.text = "Objective: " + currentObjective.objectiveName + "\n" + currentObjective.count + "/" + currentObjective.requiredCount + "\n" + "remaining times: " + timer;

    }

    void DecrementTimer()
    {
        timer--;
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
        objectiveText.text = "Objective: " + currentObjective.objectiveName + "\n" + currentObjective.count +"/" + currentObjective.requiredCount + "\n" + "remaining times: " + currentObjective.beforeEnd;
        
    }

    ObjectiveObject GetCurrentObjective()
    {
        int randomIndex = UnityEngine.Random.Range(0, objectiveObjects.Count);

        return objectiveObjects[randomIndex];
    }


}
