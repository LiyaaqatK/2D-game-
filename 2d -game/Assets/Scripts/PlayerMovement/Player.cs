using System.Net;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletSpawnPoint;
    [Header("Look")]
    [SerializeField]
    private Transform _headWrapper;
    [SerializeField]
    private Transform _WeaponWrapper;
    [SerializeField]
    private float _topAngleLimit = 40f;
    [SerializeField]
    private float _bottonAngleLimit = -20f;
    [SerializeField]
    private bool _flipTowardsMouse = true;
    [SerializeField]
    public Transform endPoint;


    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    private PlayerInputSet input;
    private StateMachine stateMachine;

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerMoveBackwards moveBackWards { get; private set; }

    public Jumping jumping { get; private set; }
    public PlayerFalling playerFalling { get; private set; }

    public Vector2 moveImput { get; private set; }

    public Vector2 _mouseWorldPos;

    [Header("Movement Details")]
    public float moveSpeed;
    public bool facingRight = true;
    public float jumpForce = 8.0f;
    [Range(0,1)]
    public float inAirMoveForce = 0.7f;

    [Header("Collision dectection")]
    [SerializeField]
    private float groundCheckDistance;
    [SerializeField]
    private LayerMask whatIsGround;
    public bool groundDetected;




    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInputSet();
        stateMachine = new StateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "moveForward");
        moveBackWards = new PlayerMoveBackwards(this, stateMachine, "moveBackwards");
        jumping = new Jumping(this, stateMachine, "jumpFall");
        playerFalling = new PlayerFalling(this, stateMachine, "jumpFall");

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
        HandleCollectionDetection();
        stateMachine.UpdateActiveState();        
        lookAtMouse();

        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }

    private void OnLook()
    {
        _mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
    }


    private void lookAtMouse()
    {
        var direction = (_mouseWorldPos - (Vector2)_headWrapper.position).normalized;
        var headdirection = (_mouseWorldPos - (Vector2)_WeaponWrapper.position).normalized;
        if (_flipTowardsMouse)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveImput.x), 1, 1);
        }
        _headWrapper.right = direction * Mathf.Sign(transform.localScale.x);
        _WeaponWrapper.right = headdirection * Mathf.Sign(transform.localScale.x);
        var eulerDir = _headWrapper.localEulerAngles;
        eulerDir.z = Mathf.Clamp(eulerDir.z - (eulerDir.z > 180 ? 360 : 0), _bottonAngleLimit, _topAngleLimit);
        _headWrapper.localEulerAngles = eulerDir;
        //_WeaponWrapper.localEulerAngles = eulerDir;
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

    private void HandleCollectionDetection()
    {
        groundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround );
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
    }



}



