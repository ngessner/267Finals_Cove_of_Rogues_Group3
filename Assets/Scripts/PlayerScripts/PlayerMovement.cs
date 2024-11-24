using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public float movementSpeed = 3f;
    public float dashForce = 4f;

    //used to change between dashing and normal movement
    private float activeMovementSpeed;

    private Vector2 movementInput;

    private float dashTime = 0.5f;
    private float dashCooldown = 1f;

    //timers used for the cooldown and length of the dash
    private float dashTimer;
    private float dashCooldownTimer;

    //code for player movement, dashing, and opening chests

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        activeMovementSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

        dash();

        //add code to open chests
    }

    private void movePlayer()
    {
        //W and S to move up and down
        //A and D to move left and right

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        playerRB.velocity = movementInput * activeMovementSpeed;
    }

    //basic dash code
    //may change
    private void dash()
    {
        //Space to dash
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCooldownTimer <= 0 && dashTimer <= 0)
            {
                activeMovementSpeed = dashForce;
                dashTimer = dashTime;
            }
        }

        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;

            if(dashTimer <= 0)
            {
                activeMovementSpeed = movementSpeed;
                dashCooldownTimer = dashCooldown;
            }
        }

        if(dashCooldownTimer > 0) 
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }
}
