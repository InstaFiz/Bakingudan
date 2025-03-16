using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DischargeDamage : MonoBehaviour
{
    bool active = false;
    bool canAttack = true;
    public KeyCode attackButton;
    public GameObject curPlayer;
    private GameObject playerDamaged;
    private PlatformerPlayerController playerController;
    private PlatformerPlayerController curPlayerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            playerDamaged = collision.gameObject;
            playerController = playerDamaged.GetComponent<PlatformerPlayerController>();

            if (playerController.theKing == true)
            {
                active = false;
                playerController.health -= 5;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Renderer>().enabled = false;
        curPlayerController = curPlayer.GetComponent<PlatformerPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackButton) && curPlayerController.theKing == false && canAttack == true)
        {
            //GetComponent<Renderer>().enabled = true;
            canAttack = false;
            active = true;

            HideDischarge();
            Cooldown();
        }
    }

    IEnumerator HideDischarge()
    {
        yield return new WaitForSeconds(0.5f);
        //GetComponent<Renderer>().enabled = false;
        active = false;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1.0f);
        canAttack = true;
    }
}
