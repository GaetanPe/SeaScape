using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius;

    /*
    void Update()
    {
        if(Vector3.Distance(GameManager.playerInstance.transform.position, this.transform.position) <= radius)
            interact();
    }
    */

    // Interact method -> To be overridden
    public virtual void interact()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}