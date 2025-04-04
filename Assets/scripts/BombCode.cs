using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCode : MonoBehaviour
{

    // [Header("Bomb")]


    public KeyCode inputKey; // Unique input key per player
    public GameObject preBomb; // Bomb prefab
    public Transform bombHoldPoint; // Where the bomb is held before throwing
    public float throwForce = 10f;
    private GameObject heldBomb = null; // Track if the player is holding a bomb
    private PlatformerPlayerController playerController;
    public GameObject crown; // Reference to the crown object
    public GameObject normalBomb;
    public GameObject crownBomb;


    void Start()
    {
        playerController = GetComponent<PlatformerPlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            if (heldBomb == null)
            {
                PickUpBomb();
            }
            else
            {
                ThrowBomb();
            }
        }
    }

    void PickUpBomb()
    {
        GameObject bombToSpawn = playerController.theKing ? crownBomb : normalBomb;
        heldBomb = Instantiate(bombToSpawn, bombHoldPoint.position, Quaternion.identity);
        heldBomb.transform.parent = bombHoldPoint;
        heldBomb.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void ThrowBomb()
    {
        if (heldBomb == null) return; // Prevent errors

        heldBomb.transform.parent = null; // Detach from player
        Rigidbody2D bombRb = heldBomb.GetComponent<Rigidbody2D>();
        bombRb.isKinematic = false; // Enable physics movement
        bombRb.velocity = new Vector2(transform.localScale.x * throwForce, 5f); // Apply throw force

        // Start bomb explosion timer
        Bomb bombScript = heldBomb.GetComponent<Bomb>();
        if (bombScript != null)
        {
            // If player has the crown, increase bomb damage
            bombScript.damage = playerController.theKing ? 25 : 15;

            bombScript.StartExplosionTimer();
        }
        else
        {
            Debug.LogError("Bomb prefab is missing the Bomb script!");
        }

        heldBomb = null; // Reset held bomb

        // **Reduce Durability if Player Has the Crown**
        if (playerController.theKing)
        {
            playerController.durability -= 1;
            Debug.Log("Crown Player Durability: " + playerController.durability);

            // If durability reaches zero, remove the crown
            if (playerController.durability <= 0)
            {
                RemoveCrown();
            }
        }
    }

    void RemoveCrown()
    {
        playerController.theKing = false; // Player loses the crown
        crown.GetComponent<CrownScript>().active = true; // Make the crown available for others
        Debug.Log("Crown lost due to durability depletion!");
    }
}