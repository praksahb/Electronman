
using UnityEngine;

public class WireCollider : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D triggerCollider)
    {
        PlayerMovementController playerMovementController = triggerCollider.gameObject.GetComponent<PlayerMovementController>();
        Debug.Log("Test1");

        if (playerMovementController != null)
        {
            if (gameObject.transform.position.y > playerMovementController.transform.position.y)
                playerMovementController.ApplyUpwardForce();
            
            if (gameObject.transform.position.y < playerMovementController.transform.position.y)
                playerMovementController.ApplyDownwardForce();
        }
    }
   
}
