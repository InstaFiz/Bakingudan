using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public int damageAmount = 15; // Default damage (updated by bomb)
    private bool active = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.CompareTag("Player"))
        {
            Player1 player1 = collision.gameObject.GetComponent<Player1>();
            if (player1 != null)
            {
                active = false; // Prevent multiple hits
                player1.TakeDamage(damageAmount);
                return;
            }

            Player2 player2 = collision.gameObject.GetComponent<Player2>();
            if (player2 != null)
            {
                active = false; // Prevent multiple hits
                player2.TakeDamage(damageAmount);
            }
        }
    }

    void Start()
    {
        GetComponent<Renderer>().enabled = false; // Hide the explosion trigger
    }
}
