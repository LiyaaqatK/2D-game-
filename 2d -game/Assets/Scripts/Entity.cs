using UnityEngine;

public class Entity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    protected StateMachine stateMachine;
    
    public GameObject bullet;
    




    [Header("Collision dectection")]
    [SerializeField]
    private float groundCheckDistance;
    [SerializeField]
    private LayerMask whatIsGround;
    public bool groundDetected;




    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        

    }

    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {
        
        
        stateMachine.UpdateActiveState(); 
               
        
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
    }


    //referenced in player and enmey script
    protected void HandleCollectionDetection()
    {
        groundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
    }


}
