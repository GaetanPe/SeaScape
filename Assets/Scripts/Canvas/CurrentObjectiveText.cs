using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentObjectiveText : MonoBehaviour
{
    [SerializeField] private ObjectiveManager manager;
    [SerializeField] private TextMeshProUGUI objectiveText;
    
    private void LateUpdate()
    {

    }
    void newObjectif()
    {
        objectiveText.text = "Current Objective: " + manager.GetCurrentObjective();
    }
}
