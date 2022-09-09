using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float PlayerMoveSpeed = 5f;

    private Rigidbody2D playerb2d;
    private float horizontal;
    private float vertical;

    private void Awake()
    {
        playerb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TakeInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void TakeInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        if (horizontal != 0)
        {
            playerb2d.AddForce(new Vector2(PlayerMoveSpeed * horizontal, 0));
        }

        playerb2d.AddForce(new Vector2(0, PlayerMoveSpeed * vertical));
    }

    public void ApplyDownwardForce()
    {
        playerb2d.AddForce(new Vector2(0, - PlayerMoveSpeed * vertical));
    }
}
