using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{


    public AudioClip jumpSound;
    

    private AudioSource playerAudio;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;

    public string horizontalNum;
    public string jumpNum;

    public bool theKing = false;
    public GameObject crownVanity;

    public int health = 1000;
    public int durability = 0;

    public bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

	if (GroundCheck == null)
	    Debug.LogError("GroundCheck not assigned to the player controller!");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis(horizontalNum);

        if (Input.GetButtonDown(jumpNum) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        crownVanity.GetComponent<Renderer>().enabled = theKing;

        if (health <= 0)
        {
            ScoreManager.gameOver = true;
            Object.Destroy(gameObject);
        }

        if (durability <= 0)
        {
            theKing = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
	    isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);

        if (horizontalInput > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }
}
