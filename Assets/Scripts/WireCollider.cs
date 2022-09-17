using UnityEngine;

public class WireCollider : MonoBehaviour
{
    private PlayerMovementController playerMovementController;
    private PlayerPlusMovementController ppmController;


    //[SerializeField]
    //private PlayerPlusMovementController ppController;

    private float transformDifference;

    [SerializeField]
    private WireAxis wireObjAxis;

    private void Awake()
    {

    }

    private void Update()
    {
        //if(wireObjAxis == WireAxis.horizontal && ppController.GetWireOnValue() != WireAxis.horizontal)
        //{
        //    ppController.SwitchInputDirection();
        //}

        //if(wireObjAxis == WireAxis.vertical && ppController.GetWireOnValue() != WireAxis.vertical)
        //{
        //    ppController.SwitchInputDirection();
        //}
    }


    private void OnTriggerStay2D(Collider2D triggerCollider)
    {
        playerMovementController = triggerCollider.gameObject.GetComponent<PlayerMovementController>();

        ppmController = triggerCollider.gameObject.GetComponent<PlayerPlusMovementController>();

        if (wireObjAxis == WireAxis.horizontal)
        {
            if (playerMovementController != null)
            {
                if (playerMovementController.GetWireOnValue() != WireAxis.horizontal)
                    playerMovementController.SwitchInputDirection();

                // gameObject.transform is wire.
                // subtracted by playergameObject.transform
                transformDifference = Mathf.Round(transform.position.y - playerMovementController.transform.position.y);

                //Debug.Log(transformDifference);
                if (transformDifference > 0)
                {
                    PlayerMovementController.direction = Direction.down;
                    playerMovementController.ApplyForceAroundWireY((int)transformDifference);
                }

                if (transformDifference < 0)
                {
                    PlayerMovementController.direction = Direction.up;
                    playerMovementController.ApplyForceAroundWireY((int)transformDifference);
                }
            }

            if(ppmController != null)
            {
                if (ppmController.GetWireOnValue() != WireAxis.horizontal)
                    ppmController.SwitchInputDirection();

                transformDifference = Mathf.Round(transform.position.y - ppmController.transform.position.y);
                if(transformDifference > 0)
                {
                    ppmController.ApplyForceAroundWireY((int)transformDifference);
                }
                if(transformDifference < 0)
                {
                    ppmController.ApplyForceAroundWireY((int)transformDifference);
                }
            }
        }

        if (wireObjAxis == WireAxis.vertical)
        {
            if (playerMovementController != null)
            {
                if (playerMovementController.GetWireOnValue() != WireAxis.vertical)
                    playerMovementController.SwitchInputDirection();

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
            if (ppmController != null)
            {
                if (ppmController.GetWireOnValue() != WireAxis.vertical)
                    ppmController.SwitchInputDirection();

                transformDifference = Mathf.Round(transform.position.x - ppmController.transform.position.x);

                Debug.Log(transformDifference);
                if (transformDifference > 0)
                {
                    ppmController.ApplyForceAroundWireX((int)transformDifference);
                }
                if (transformDifference < 0)
                {
                    ppmController.ApplyForceAroundWireX((int)transformDifference);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    //    playerMovementController = collision.gameObject.GetComponent<PlayerMovementController>();

    //    if (playerMovementController != null)
    //    {
    //        // playerMovementController.DechargeJump();
    //        if(PlayerMovementController.direction == Direction.up)
    //        {
    //            playerMovementController.DischargeForce(wireObjAxis, Direction.down);
    //        }
    //        if(PlayerMovementController.direction == Direction.down)
    //        {
    //            playerMovementController.DischargeForce(wireObjAxis, Direction.up);
    //        }
    //    }
    }
}
