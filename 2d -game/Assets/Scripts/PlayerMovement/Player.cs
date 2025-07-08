using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    [Header("Look")]
    [SerializeField]
    private Transform _headWrapper;
    [SerializeField]
    private float _topAngleLimit = 40f;
    [SerializeField]
    private float _bottonAngleLimit = -20f;
    [SerializeField]
    private bool _flipTowardsMouse = true;


    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    private PlayerInputSet input;
    private StateMachine stateMachine;

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerMoveBackwards moveBackWards { get; private set; }

    public Vector2 moveImput { get; private set; }

    public Vector2 _mouseWorldPos;

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
        flipController();
        OnLook();
        stateMachine.UpdateActiveState();        
        lookAtMouse();
    }

    private void OnLook()
    {
        _mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Does mose ever run");
    }


    private void lookAtMouse()
    {
        var direction = (_mouseWorldPos - (Vector2)_headWrapper.position).normalized;
        if(_flipTowardsMouse)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveImput.x), 1, 1);
        }
        _headWrapper.right = direction * Mathf.Sign(transform.localScale.x);
        var eulerDir = _headWrapper.localEulerAngles;
        eulerDir.z = Mathf.Clamp(eulerDir.z - (eulerDir.z > 180 ? 360 : 0), _bottonAngleLimit, _topAngleLimit);
        _headWrapper.localEulerAngles = eulerDir;
    }




    public void flipController()
    {

        Vector2 playerPos = this.transform.position;
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        float mousePosX = mousePos.x - playerPos.x;
        if(mousePosX > 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(1), 1, 1);
            facingRight = true;
        }
        else if (mousePosX < 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(-1), 1, 1);
            facingRight = false;
        }

    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
    }


}
