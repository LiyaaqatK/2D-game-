using UnityEngine;

public class Sliding : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private CollsionGroundCheck groundCheck;
    private Sprinting checkIfSprinting;
    [SerializeField] private bool isSliding = false;

    [Header("slide parameters")]
    [SerializeField] private float slideForce = 12f;
    [SerializeField] private float slideDuration = 0.4f;



    public bool IsSliding
    {
        get{return isSliding;}
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<CollsionGroundCheck>();
        checkIfSprinting = GetComponent<Sprinting>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C) && !isSliding)
        {
            if (checkIfSprinting.IsSprinting && groundCheck.IsGrounded)
            {
                StartSlide();
            }
        }

        
        if (isSliding)
        {
            slideDuration -= Time.deltaTime;

            if (slideDuration <= 0)
            {
                EndSlide();
            }
        }

    }
    private void StartSlide()
    {
        isSliding = true;

        float direction;
        if (playerRb.linearVelocity.x > 0)
        {
            direction = 1.0f;
        }
        else
        {
            direction = -1.0f;
        }
        playerRb.AddForce(new Vector2(direction * slideForce, 0), ForceMode2D.Impulse);

        Debug.Log("Player has started sliding.");
    }
    
    private void EndSlide()
    {
        isSliding = false;

        Debug.Log("Player stoped slide.");
    }

}