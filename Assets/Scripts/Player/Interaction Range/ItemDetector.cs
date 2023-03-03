using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    [Header("\t--- Radius")]
    public float interactRadius;

    // [Header("\t--- GameObject interacted")]
    // protected GameObject interactable;




    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Item")
            c.GetComponent<InteractableItem>().interact();
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}