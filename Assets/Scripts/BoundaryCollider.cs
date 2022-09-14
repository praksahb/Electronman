using UnityEngine;

public class BoundaryCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider2d;

    private PlayerMovementController playerMovementController;

    //private int negativeMultiplier4Direction = 1;

    private void Awake()
    {
        boxCollider2d = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //if (PlayerMovementController.GetCJValue() > 0.2)
        //{
        //    boxCollider2d.enabled = false;
        //}
        //else
        //{
        //    boxCollider2d.enabled = true;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovementController = collision.gameObject.GetComponent<PlayerMovementController>();

        if (playerMovementController != null)
        {
            playerMovementController.DechargeJump();
        }
    }

    private void CollisionEnter2D(Collision2D collision)
    {

    }

}
