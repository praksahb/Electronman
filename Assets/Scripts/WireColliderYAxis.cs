using UnityEngine;

public class WireColliderYAxis : MonoBehaviour
{

    private PlayerMovementController playerMovementController;

    private float transformDifference;


    [SerializeField]
    private WireAxis wireObjAxis;

    private void OnTriggerStay2D(Collider2D triggerCollider)
    {
        playerMovementController = triggerCollider.gameObject.GetComponent<PlayerMovementController>();

        if (playerMovementController != null)
        {
            // gameObject.transform is wire.
            // subtracted by playergameObject.transform
            transformDifference = Mathf.Round(transform.position.x - playerMovementController.transform.position.x);

            if (transformDifference > 0)
            {
                PlayerMovementController.direction = Direction.down;
                playerMovementController.ApplyForceAroundWireX((int)transformDifference);
            }

            if (transformDifference < 0)
            {
                PlayerMovementController.direction = Direction.up;
                playerMovementController.ApplyForceAroundWireX((int)transformDifference);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovementController = collision.gameObject.GetComponent<PlayerMovementController>();

        if (playerMovementController != null)
        {
            playerMovementController.DechargeJump();
        }
    }
}
