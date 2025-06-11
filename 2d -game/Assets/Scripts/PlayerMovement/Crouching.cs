using UnityEngine;

public class Crouching : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private CollsionGroundCheck groundCheck;
    public bool IsCrouching { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<CollsionGroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCrouch();
    }

    private void HandleCrouch()
    {
        // Only allow crouch if grounded
        if (playerRb.linearVelocity.x == 0 && groundCheck.IsGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))  // Press Left Ctrl to crouch
            {
                IsCrouching = true;
                Debug.Log("Player is crouching");
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                IsCrouching = false;
                Debug.Log("Player is standing");
            }
        }
        else
        {
            IsCrouching = false;
        }
    }
    
}
