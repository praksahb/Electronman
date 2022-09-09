
using UnityEngine;

public class WireCollider : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Test");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerMovementController playerMovementController = collision.gameObject.GetComponent<PlayerMovementController>();
        Debug.Log("Test1");

        if (playerMovementController != null)
        {
            Debug.Log("Test2");
            //playerMovementController.ApplyDownwardForce();
        }
    }

   
}
