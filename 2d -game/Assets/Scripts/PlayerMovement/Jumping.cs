using UnityEngine;

public class Jumping : MonoBehaviour
{
    public Rigidbody2D playerRb;
    [SerializeField] private float jumpForce = 5.0f;
    private CollsionGroundCheck groundCheck; //CollisionGroundCheck script


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<CollsionGroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {     
        Jump();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.IsGrounded)
        {
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);   
        }
    }

}
