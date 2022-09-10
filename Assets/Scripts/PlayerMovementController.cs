using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float playerForceFactor;

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
            playerb2d.AddForce(new Vector2(playerForceFactor * horizontal, 0));
        }
        if (vertical != 0)
        playerb2d.AddForce(new Vector2(0, playerForceFactor * vertical));
    }

    public void ApplyDownwardForce()
    {
        playerb2d.AddForce(new Vector2(0, - playerForceFactor / 4), ForceMode2D.Force);
    }

    public void ApplyUpwardForce()
    {
        playerb2d.AddForce(new Vector2(0, playerForceFactor / 4), ForceMode2D.Force);
    }

    public void BoundaryPullPushForce()
    {
        playerb2d.AddForce(new Vector2(0, -playerForceFactor), ForceMode2D.Impulse);
    }
}