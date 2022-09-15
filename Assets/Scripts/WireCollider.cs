using UnityEngine;

public class WireCollider : MonoBehaviour
{
    private PlayerMovementController playerMovementController;

    private float transformDifference;

    [SerializeField]
    private WireAxis wireObjAxis;

    private void Awake()
    {

    }


    private void OnTriggerStay2D(Collider2D triggerCollider)
    {
        playerMovementController = triggerCollider.gameObject.GetComponent<PlayerMovementController>();

        if (wireObjAxis == WireAxis.horizontal)
        {

            if (playerMovementController != null)
            {
                // gameObject.transform is wire.
                // subtracted by playergameObject.transform
                transformDifference = Mathf.Round(transform.position.y - playerMovementController.transform.position.y);

                //Debug.Log(transformDifference);
                if (transformDifference > 0)
                {
                    PlayerMovementController.direction = Direction.down;
                    playerMovementController.ApplyForceAroundWire((int)transformDifference);
                }

                if (transformDifference < 0)
                {
                    PlayerMovementController.direction = Direction.up;
                    playerMovementController.ApplyForceAroundWire((int)transformDifference);
                }
            }
        }

        if (wireObjAxis == WireAxis.vertical)
        {
            if (playerMovementController != null)
            {
                transformDifference = Mathf.Round(transform.position.x - playerMovementController.transform.position.x);

                Debug.Log(transformDifference);
                if (transformDifference > 0)
                {
                    PlayerMovementController.direction = Direction.right;
                    playerMovementController.ApplyForceAroundWireX((int)transformDifference);
                }
                if (transformDifference < 0)
                {
                    PlayerMovementController.direction = Direction.left;
                    playerMovementController.ApplyForceAroundWireX((int)transformDifference);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovementController = collision.gameObject.GetComponent<PlayerMovementController>();

        if (playerMovementController != null)
        {
            // playerMovementController.DechargeJump();
            if(PlayerMovementController.direction == Direction.up)
            {
                playerMovementController.DischargeForce(wireObjAxis, Direction.down);
            }
            if(PlayerMovementController.direction == Direction.down)
            {
                playerMovementController.DischargeForce(wireObjAxis, Direction.up);
            }
        }
    }

}
