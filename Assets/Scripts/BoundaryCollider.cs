using UnityEngine;

public class BoundaryCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider2d;

    private PlayerMovementController playerMovementController;

    private void Awake()
    {
        boxCollider2d = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovementController = collision.gameObject.GetComponent<PlayerMovementController>();
    
        if(playerMovementController != null)
        {
            playerMovementController.BoundaryPullPushForce();
        }
    }

}
