using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float playerForceFactor;

    private Rigidbody2D playerRigidBody2d;
    private float horizontal;

    private float vertical;

    private bool chargeJump;

    // using static as a shortcut
    //implement without using static when done
    public static Direction direction;


    [SerializeField]
    private float chargeJumpValue;


    private void Awake()
    {
        playerRigidBody2d = GetComponent<Rigidbody2D>();
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

        //moveXleft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow);

        chargeJump = Input.GetKeyDown(KeyCode.LeftControl);
    }

    private void MovePlayer()
    {
        if (horizontal != 0)
        {
            playerRigidBody2d.AddForce(new Vector2(playerForceFactor * horizontal, 0));
        }


        if (vertical != 0)
            playerRigidBody2d.AddForce(new Vector2(0, playerForceFactor * vertical));

        if (chargeJump)
        {
            ChargeJump();
        }
    }

    private void ChargeJump()
    {
        playerRigidBody2d.AddForce(new Vector2(0, playerForceFactor * chargeJumpValue * (int)direction), ForceMode2D.Impulse);
    }

    public void DechargeJump()
    {
        playerRigidBody2d.velocity = new Vector2(0, 0);

        //playerigidBody2d.AddForce(new Vector2(0, -playerForceFactor * chargeJumpValue * multiple4Direction), ForceMode2D.Impulse);
    }

    public  void DischargeForce(WireAxis wireDir, Direction oppDir)
    {
        if (wireDir == WireAxis.horizontal)
            playerRigidBody2d.AddForce(new Vector2(0, 10 * (int)oppDir * playerForceFactor));

        if(wireDir == WireAxis.vertical)
            playerRigidBody2d.AddForce(new Vector2(10 * (int)oppDir * playerForceFactor, 0));

    }

    public void ApplyForceAroundWire(int distanceFactor)
    {
        if (!chargeJump)
            playerRigidBody2d.AddForce(new Vector2(0, playerForceFactor * distanceFactor), ForceMode2D.Force);
    }

    public void ApplyForceAroundWireX(int distanceFactor)
    {
        if (!chargeJump)
            playerRigidBody2d.AddForce(new Vector2(playerForceFactor * distanceFactor, 0), ForceMode2D.Force);
    }

    //public void ApplyDownwardForce(float distanceFactor)
    //{
    //    if (!chargeJump)
    //        playerRigidBody2d.AddForce(new Vector2(0, -(playerForceFactor) * distanceFactor), ForceMode2D.Force);
    //}

    //public void ApplyUpwardForce(float distanceFactor)
    //{
    //    if (!chargeJump)
    //        playerRigidBody2d.AddForce(new Vector2(0, (playerForceFactor) * distanceFactor), ForceMode2D.Force);
    //}
}