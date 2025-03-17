using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class PlatformerPlayerController : MonoBehaviour
{
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
    public GameObject crownPrefab;

    public int health = 15;
    public int maxHealth = 15;

    public TextMeshProUGUI scoreText; // UI reference for score display

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (GroundCheck == null)
            Debug.LogError("GroundCheck not assigned to the player controller!");

        UpdateScoreUI(); // Initialize the score UI at the start
    }

    void Update()
    {
        horizontalInput = Input.GetAxis(horizontalNum);

        if (Input.GetButtonDown(jumpNum) && isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        crownVanity.GetComponent<Renderer>().enabled = theKing;

        if (health <= 0 && theKing)
        {
            DropCrown();
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

    public void TakeDamage(int damage)
    {
        if (theKing)
        {
            health -= damage;
            UpdateScoreUI(); // Update the UI when health changes

            if (health <= 0)
            {
                DropCrown();
            }
        }
    }

    void DropCrown()
    {
        theKing = false;
        health = maxHealth;
        UpdateScoreUI(); // Update UI when the crown is lost

        Instantiate(crownPrefab, transform.position, Quaternion.identity);
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "King's Health: " + health;
        }
    }

}
