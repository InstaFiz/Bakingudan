using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownScript : MonoBehaviour
{
    public bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player") //if trigger zone is active and is touching an object registered as player
        {
            active = false;
            collision.gameObject.GetComponent<PlatformerPlayerController>().theKing = true;
            collision.gameObject.GetComponent<PlatformerPlayerController>().durability = 10;
        }


    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().enabled = active;
    }
}
