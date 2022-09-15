using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlusMovementController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementController playerMovementController;

    private Transform pTransform;
    private Vector3 prevPosition;
    private Vector3 deltaMove;


    private void Awake()
    {
        pTransform = playerMovementController.gameObject.transform;
    }

    private void Start()
    {
        prevPosition = pTransform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        deltaMove = pTransform.position - prevPosition;
        prevPosition = pTransform.position;

        Vector3 position = transform.position;

        if (Mathf.Abs(pTransform.position.x - transform.position.x) < 1)
        {
            position += new Vector3(deltaMove.x * -1, deltaMove.y * -1);
        }
        else
        {
            position += new Vector3(deltaMove.x, deltaMove.y * -1);
        }

        //position += new Vector3(deltaMove.x, deltaMove.y * -1);

        transform.position = position;
    }
}
