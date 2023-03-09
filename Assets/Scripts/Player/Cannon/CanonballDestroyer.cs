using UnityEngine;

public class CanonballDestroyer : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y <= -20)
            Destroy(gameObject);
    }
}
