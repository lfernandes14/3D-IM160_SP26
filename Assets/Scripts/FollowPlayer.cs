using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;


    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
