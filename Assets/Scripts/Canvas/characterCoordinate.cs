using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class characterCoordinate : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    void LateUpdate()
    {
       float x = playerTransform.position.x;
       float z = playerTransform.position.z;
       textMeshProUGUI.text = "X: " + x + " Z: " + z ;
    }
}
