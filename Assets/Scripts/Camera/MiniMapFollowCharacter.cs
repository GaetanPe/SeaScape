using UnityEngine;

public class MiniMapFollowCharacter : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPostion= player.position;
        newPostion.y = transform.position.y;
        transform.position = newPostion;
    }
}
