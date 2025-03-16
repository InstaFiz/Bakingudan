using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCode : MonoBehaviour
{

    // [Header("Bomb")]


    public KeyCode inputKey = KeyCode.LeftShift;
    public GameObject preBomb; // Bomb prefab
    public Transform bombHoldPoint; // Where the bomb is held before throwing
    public float throwForce = 10f;
    private GameObject heldBomb = null; // Track if the player is holding a bomb
    private PlatformerPlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlatformerPlayerController>();
    }

    void Update()
    {
        if (playerController.theKing) // Only allow bomb pickup/throw if player has crown
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
    }

    void PickUpBomb()
    {
        heldBomb = Instantiate(preBomb, bombHoldPoint.position, Quaternion.identity);
        heldBomb.transform.parent = bombHoldPoint; // Attach bomb to player
        heldBomb.GetComponent<Rigidbody2D>().isKinematic = true; // Prevent movement while held
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
            bombScript.StartExplosionTimer();
        }
        else
        {
            Debug.LogError("Bomb prefab is missing the Bomb script!");
        }

        heldBomb = null; // Reset held bomb
    }
}