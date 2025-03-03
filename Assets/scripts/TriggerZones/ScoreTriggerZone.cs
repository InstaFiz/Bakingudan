using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class ScoreTriggerZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
       bool active = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (active && collision.gameObject.tag == "Player")
        {
            active = false;

            ScoreManager.score++;

            //to destroy game object
            Destroy(gameObject);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
