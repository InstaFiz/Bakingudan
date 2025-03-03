using System.Collections;
using System.Collections.Generic;
using TMPro; //need this to use textMexhPro
using UnityEngine;

public class TriggerZone : MonoBehaviour
{

    //set this reference in the inspector
    public TMP_Text output;

    //enter the text you want to display
    public string textToDsiplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ///Debug.Log("Triggered by " + collision.gameObject.name);//sends a message to the console
        ///

        //set the player tag in the inpsector
        if (collision.gameObject.tag == "Player") {
            //display "you win!" on the screen
            output.text = textToDsiplay; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
