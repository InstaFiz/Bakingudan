using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update, basically this starts when the game boots up


    //Set this reference in the inspector
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position;

        // transform.position = player.transform.position;//could put gameObject infront of the first transform.position but no neccassy
        transform.position = new Vector3 (

        player.transform.position.x, //only changing x and y to match player's position
        player.transform.position.y,
        transform.position.z);
        
    }
}
