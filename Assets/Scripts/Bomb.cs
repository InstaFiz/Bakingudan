using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionDelay = 3f; // Time before explosion
    public GameObject explosionEffect; // Assign an explosion animation or particle effect
    private bool hasExploded = false;
    public int damage = 25; // Default bomb damage (increased if thrown by king)

    void Start()
    {
        // The bomb should only explode after being thrown
    }

    // This function starts the explosion countdown
    public void StartExplosionTimer()
    {
        StartCoroutine(ExplodeAfterDelay());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasExploded && (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall")))
        {
            Explode();
        }
    }

    IEnumerator ExplodeAfterDelay()
    {
        yield return new WaitForSeconds(explosionDelay);
        Explode();
    }

    void Explode()
    {
        if (hasExploded) return;

        hasExploded = true;
        if (explosionEffect)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            // Pass bomb damage to explosion
            ExplosionDamage explosionDamage = explosion.GetComponent<ExplosionDamage>();
            if (explosionDamage != null)
            {
                explosionDamage.damageAmount = damage; // Set explosion damage
            }
        }

        Destroy(gameObject); // Destroy the bomb
    }
}
