using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public float movementSpeed = 3f;
    public float dashForce = 4f;
    private Animator animator;

    //used to change between dashing and normal movement
    private float activeMovementSpeed;

    // Janky, but firepoints for shooting. Need this to update each state of the gun too.
    public Transform firePointUp;
    public Transform firePointDown;
    public Transform firePointLeft;
    public Transform firePointRight;
    private Transform currentFirepoint;

    public Vector2 movementInput;

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
        animator = GetComponent<Animator>();
        activeMovementSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

        dash();

        openChest();
        checkAnimation();

        updateFirepoint();
    }

    private void movePlayer()
    {
        //W and S to move up and down
        //A and D to move left and right

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");


        // so anims don't default to zero
        if (movementInput != Vector2.zero)
        {
            // for animator directions
            animator.SetFloat("xInput", movementInput.x);
            animator.SetFloat("yInput", movementInput.y);       
        }


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Chest"))
        {
            //drop item on ground  
        }
    }

    private void openChest()
    {

    }

    private void checkAnimation()
    {
        if (movementInput.x == 0 && movementInput.y == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

    }

    private void updateFirepoint()
    {
        if (movementInput.x > 0) 
        {
            currentFirepoint = firePointRight;
        }
        else if (movementInput.x < 0) 
        {
            currentFirepoint = firePointLeft;
        }
        else if (movementInput.y > 0) 
        {
            currentFirepoint = firePointUp;
        }
        else if (movementInput.y < 0) 
        {
            currentFirepoint = firePointDown;
        }
    }
    public Transform getCurrentFirepoint()
    {
        return currentFirepoint;
    }
}
