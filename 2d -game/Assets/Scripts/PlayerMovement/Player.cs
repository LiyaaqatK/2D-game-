using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    private PlayerInputSet input;
    private StateMachine stateMachine;

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    public Vector2 moveImput { get; private set; }

    [Header("Movement Details")]
    public float moveSpeed;

    private bool facingRight = true;



    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInputSet();
        stateMachine = new StateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");


    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += ctx => moveImput = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => moveImput = Vector2.zero;
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);

    }

    private void Update()
    {
        stateMachine.UpdateActiveState();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip(xVelocity);
    }

    private void HandleFlip(float xVelocity)
    {
        if(xVelocity > 0 && facingRight == false)
        {
            Flip();
        }
        else if (xVelocity < 0 && facingRight == true)
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }
}
