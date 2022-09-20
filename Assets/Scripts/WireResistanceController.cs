using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireResistanceController : MonoBehaviour
{
    private PlayerMovementController playerMovementController;

    [SerializeField]
    private float wireResistance;

    private void Awake()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerMovementController = collision.gameObject.GetComponent<PlayerMovementController>();

        if(playerMovementController != null)
        {
            playerMovementController.ApplyWireResistanceForce(wireResistance);
        }
    }
}
