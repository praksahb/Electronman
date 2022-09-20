using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float playerForceFactor;

    // [SerializeField]
    //private PlayerPlusMovementController ppController;

    private Rigidbody2D playerRigidBody2d;
    private float horizontal;

    private float vertical;

    private bool chargeJump;
    private WireAxis WireOn;

    // using static as a shortcut
    //implement without using static when done

    public static Direction direction;

    [SerializeField]
    private float totalChargeValue;
    private float chargeValue;

    private void Awake()
    {
        playerRigidBody2d = GetComponent<Rigidbody2D>();

        //level 1 - initial
        WireOn = WireAxis.vertical;

        chargeValue = totalChargeValue;
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
        if (WireOn == WireAxis.horizontal)
        {
            horizontal = Input.GetAxis("Horizontal");
            chargeValue -= Mathf.Abs(horizontal);
        }

        if (WireOn == WireAxis.vertical)
        {
            vertical = Input.GetAxis("Vertical");
            chargeValue -= Mathf.Abs(vertical);
        }

        //moveXleft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow);

        chargeJump = Input.GetKeyDown(KeyCode.LeftControl);
    }

    private void MovePlayer()
    {
        if (WireOn == WireAxis.horizontal)
        {
            if (horizontal != 0)
            {
                playerRigidBody2d.AddForce(new Vector2(playerForceFactor * horizontal, 0));
            }
        }

        if (WireOn == WireAxis.vertical)
        {
            if (vertical != 0)
            {
                playerRigidBody2d.AddForce(new Vector2(0, playerForceFactor * vertical));
            }
        }

        //if (vertical != 0)
        //    playerRigidBody2d.AddForce(new Vector2(0, playerForceFactor * vertical));

        if (chargeJump)
        {
            ChargeJump();
        }
    }

    public WireAxis GetWireOnValue()
    {
        return WireOn;
    }

    public void SwitchInputDirection()
    {
        if (WireOn == WireAxis.horizontal)
        {
            WireOn = WireAxis.vertical;
            //if (ppController.GetWireOnValue() != WireAxis.horizontal)
            //{
            //    ppController.SwitchInputDirection();
            //}
        }

        if (WireOn == WireAxis.vertical)
        {
            WireOn = WireAxis.horizontal;
            //if (ppController.GetWireOnValue() != WireAxis.vertical)
            //{
            //    ppController.SwitchInputDirection();
            //}
        }
    }

    private void ChargeJump()
    {
        playerRigidBody2d.AddForce(new Vector2(playerForceFactor * chargeValue * horizontal, playerForceFactor * chargeValue * vertical), ForceMode2D.Impulse);
    }

    public void DechargeJump()
    {
        playerRigidBody2d.velocity = new Vector2(0, 0);

        //playerigidBody2d.AddForce(new Vector2(0, -playerForceFactor * chargeJumpValue * multiple4Direction), ForceMode2D.Impulse);
    }

    public void DischargeForce(WireAxis wireDir, Direction oppDir)
    {
        if (wireDir == WireAxis.horizontal)
            playerRigidBody2d.velocity /= 2;
        if (wireDir == WireAxis.vertical)
            playerRigidBody2d.velocity /= 2;

    }

    public void ApplyForceAroundWireY(int distanceFactor)
    {
        if (!chargeJump)
            playerRigidBody2d.AddForce(new Vector2(0, playerForceFactor * distanceFactor), ForceMode2D.Force);
        //ppController.ApplyForceAroundWireY(-distanceFactor);
    }

    public void ApplyForceAroundWireX(int distanceFactor)
    {
        if (!chargeJump)
            playerRigidBody2d.AddForce(new Vector2(playerForceFactor * distanceFactor, 0), ForceMode2D.Force);
        //ppController.ApplyForceAroundWireX(-distanceFactor);
    }

    public float GetChargeValue()
    {
        //chargeValue should be determined by movement of electron - 1 rotation equals 1/5th charge increase
        // return value(float) in range of (0, 1)

        return chargeValue / totalChargeValue;
    }

    public void ApplyWireResistanceForce(float wireResistance)
    {

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