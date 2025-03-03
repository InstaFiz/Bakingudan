using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    //player move speed
    public float moveSpeed = 5f;

    //force applied when jumping
    public float jumpForce = 10f;

    //layer mask for detecting ground
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    //to keep track if we are on ground
    private bool isGrounded;


    //reference to the rigidbody 2D component
    private Rigidbody2D rb;

    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        //get the rigidbody2d to attach to this component
        rb = GetComponent<Rigidbody2D>();

        //ensure the ground check variable is assigned
        if (groundCheck == null) {
            Debug.LogError("GroundCheck not assigned to the player controller");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded) { //means if space bar is held down and we are on the ground
            //apply and upward for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        //move the player using rigidbody2D in fixedUpdate     rb.velocity.y is the current velocity on the y axis
        rb.velocity = new Vector2 (horizontalInput * moveSpeed, rb.velocity.y);

        //check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //takes the point we give it and checks within that circle if is touching what we consider the ground to be 

        //Ensure the player is facing the direction of movement
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); //facing right
        }
        else if(horizontalInput < 0) { 
            transform.localScale = new Vector3(-1f, 1f, 1f); //facing left
        }
    }




}
