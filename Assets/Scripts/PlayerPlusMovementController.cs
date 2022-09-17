using UnityEngine;

public class PlayerPlusMovementController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementController playerMovementController;
    
    [SerializeField]
    private float playerForceFactor;

    private Transform pTransform;
    private Vector3 prevPosition;
    private Vector3 deltaMove;


    private Rigidbody2D playerigidbody2D;

    private float horizontal;
    private float vertical;

    private WireAxis WireOn;

    //private void Awake()
    //{
    //    pTransform = playerMovementController.gameObject.transform;
    //    WireOn = WireAxis.horizontal;
    //}

    private void Awake()
    {
        playerigidbody2D = GetComponent<Rigidbody2D>();
        WireOn = WireAxis.horizontal;
    }

    //private void Start()
    //{
    //    prevPosition = pTransform.position;
    //}

    //void Update()

    //{
    //    deltaMove = pTransform.position - prevPosition;
    //    prevPosition = pTransform.position;

    //    Vector3 position = transform.position;

    //    //if (Mathf.Abs(pTransform.position.x - transform.position.x) < 1)
    //    //{
    //    //    position += new Vector3(deltaMove.x * -1, deltaMove.y * -1);
    //    //}
    //    //else
    //    //{
    //    //    position += new Vector3(deltaMove.x, deltaMove.y * -1);
    //    //}

    //    //if(WireOn == WireAxis.horizontal)
    //    {
    //        position += new Vector3(deltaMove.x * -1, deltaMove.y * -1);
    //    }

    //    //if(WireOn == WireAxis.vertical)
    //    //{
    //    //    position += new Vector3(deltaMove.x * -1, deltaMove.y);
    //    //}

    //    transform.position = position;
    //}

    public WireAxis GetWireOnValue()
    {
        return WireOn;
    }

    public void SwitchInputDirection()
    {
        if (WireOn == WireAxis.horizontal)
        {
            WireOn = WireAxis.vertical;
            Debug.Log("Wire on: " + WireOn);
        }

        if (WireOn == WireAxis.vertical)
        {
            WireOn = WireAxis.horizontal;
            Debug.Log("Wire on: " + WireOn);
        }
    }

    private void Update()
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
        if (WireOn == WireAxis.horizontal)
            playerigidbody2D.AddForce(new Vector2(playerForceFactor * -horizontal, 0));

        if (WireOn == WireAxis.vertical)
            playerigidbody2D.AddForce(new Vector2(0, playerForceFactor * vertical));
    }

    public void ApplyForceAroundWireY(int distanceFactor)
    {
        playerigidbody2D.AddForce(new Vector2(0, playerForceFactor * distanceFactor), ForceMode2D.Force);
    }

    public void ApplyForceAroundWireX(int distanceFactor)
    {
            playerigidbody2D.AddForce(new Vector2(playerForceFactor * distanceFactor, 0), ForceMode2D.Force);
    }
}