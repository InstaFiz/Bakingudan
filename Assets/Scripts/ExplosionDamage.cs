using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    bool active = true;
    private GameObject playerDamaged;
    private PlatformerPlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            playerDamaged = collision.gameObject;
            playerController = playerDamaged.GetComponent<PlatformerPlayerController>();

            if (playerController.theKing == false)
            {
                active = false;
                playerController.health -= 25;
            }
        }
    }


// Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
