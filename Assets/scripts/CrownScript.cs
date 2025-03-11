using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool active = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player") //if trigger zone is active and is touching an object registered as player
        {
            active = false;
            if (collision.gameObject.name == "PlatformerPlayer") {
                Destroy(collision.gameObject); //destroy the object it touches
                Destroy(this.gameObject); //destroys itself

                SpawnPlayer(); //spawn in new player character
            }
  
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject playerprefab;
    public Transform spawnpoint;

    void SpawnPlayer()
    {
        // gameobject new player = make(playerobject, at old player position, don't rotate_
        GameObject newplayer = Instantiate(playerprefab, spawnpoint.position, Quaternion.identity);


    }
}
