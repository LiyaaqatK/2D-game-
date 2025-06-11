using UnityEngine;

public class CollsionGroundCheck : MonoBehaviour
{
    /*Collsion ground chechk with reference to the center of the player*/
    [Header("Collision detection groundd")]
    
    [SerializeField] private float checkGroundDistance;
    [SerializeField] private LayerMask whatIsGround;
    public bool IsGrounded{ get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleCollsions();
    }
    private void HandleCollsions()
    {
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, checkGroundDistance, whatIsGround);
    }
    //reference point from center downwards
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -checkGroundDistance));
    }
}
