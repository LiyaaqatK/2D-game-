using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private float defaultSpeed = 5.0f;
    private string lastDirection;

    private Sprinting sprintMultiplier;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sprintMultiplier = GetComponent<Sprinting>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            lastDirection = "right";
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastDirection = "left";
        }
    }

    void FixedUpdate()
    {
        HorizontalMovement();
    }
    private void HorizontalMovement()
    {
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        float speed = defaultSpeed;

        if (sprintMultiplier != null)
        {
            speed *= sprintMultiplier.GetSpeedMultiplier();
        }
        bool holdLeft = Input.GetKey(KeyCode.A);
        bool holdRight = Input.GetKey(KeyCode.D);

        if (lastDirection == "right" && holdRight)
        {
            playerRb.linearVelocity = new Vector2(speed, playerRb.linearVelocity.y);
        }
        else if (lastDirection == "left" && holdLeft)
        {
            playerRb.linearVelocity = new Vector2(-speed, playerRb.linearVelocity.y);
        }
        else
        {
            // Stop only if neither key is held
            if (!holdLeft && !holdRight)
            {
                playerRb.linearVelocity = new Vector2(0, playerRb.linearVelocity.y);
            }
        }
    }

    
    

}