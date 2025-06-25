using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera camera;
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    private PlayerInputSet input;
    private StateMachine stateMachine;

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerMoveBackwards moveBackWards { get; private set; }

    public Vector2 moveImput { get; private set; }

    [Header("Movement Details")]
    public float moveSpeed;
    public bool facingRight = true;
  



    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInputSet();
        stateMachine = new StateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "moveForward");
        moveBackWards = new PlayerMoveBackwards(this, stateMachine, "moveBackwards");

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
        flipController();
    }

    public void flipController()
    {

        Vector2 playerPos = this.transform.position;
        Vector2 mousePos = Input.mousePosition;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        float mousePosX = mousePos.x - playerPos.x;
        if(mousePosX > 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
        }
        else if (mousePosX < 0)
        {
            this.transform.eulerAngles = new Vector3(0, 180f, 0);
            facingRight = false;
        }

    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
    }


}
