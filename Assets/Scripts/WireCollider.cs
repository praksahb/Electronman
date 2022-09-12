
using UnityEngine;

public enum Direction {
    up=1 , down=-1
}

public class WireCollider : MonoBehaviour
{
    private PlayerMovementController playerMovementController;

    private float transformDifference;


    private void Awake()
    {

    }


    private void OnTriggerStay2D(Collider2D triggerCollider)
    {
        playerMovementController = triggerCollider.gameObject.GetComponent<PlayerMovementController>();

        if (playerMovementController != null)
        {
            transformDifference = transform.position.y - playerMovementController.transform.position.y;    
            
            if (transformDifference > 0)
            {
                PlayerMovementController.direction = Direction.down;
                playerMovementController.ApplyUpwardForce(Mathf.Abs(transformDifference));
            }
            
            if (transformDifference < 0)
            {
                PlayerMovementController.direction = Direction.up;
                playerMovementController.ApplyDownwardForce(Mathf.Abs(transformDifference));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovementController = collision.gameObject.GetComponent<PlayerMovementController>();

        if(playerMovementController != null)
        {
            playerMovementController.DechargeJump();
        }
    }

}
