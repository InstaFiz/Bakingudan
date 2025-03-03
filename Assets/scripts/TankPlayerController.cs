using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour //a monobehavior is a script that can be attached
{
    public float speed;
    public float turnSpeed;
    public float horizontalInput;
    public float verticalInput;


  
    // Update is called once per frame
    void Update()
    {

        //Move Forward        x, y, z   axis
        //transform.Translate(1, 0, 0);  //this will send the box flying to the right
        
        //which is the same as 
    //    transform.Translate(Vector2.right);  //going one to the right on the x axis

        //we can low this speed  down with delta time speed goes by how fast the computer is going so we scale by 
        //move to the right at 20m/s if speed is set to 20
       // transform.Translate(Vector2.right * Time.deltaTime * speed); //by adding speed we can change the speed in unity since out float vars go there

        //Get input from user - do this in Update()
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // move the player forward with vertical input
        transform.Translate(Vector2.right * speed * Time.deltaTime * verticalInput);

        //rotate player with horizontal input
        // transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * horizontalInput);
        /////////////////axis were rotating about,   float angel


        //rotate palyer with the horizontal input
        //but reverse the orientation direction when moving backwards
        if (verticalInput < 0)
        {
            transform.Rotate(Vector3.back, -turnSpeed * Time.deltaTime * horizontalInput);
        }
        else {
            transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);
        }

        //Move player side-to-side with horizontal input
        //transform.Translate(Vector2.right * turnSpeed * Time.deltaTime * horizontalInput);
    }
}
