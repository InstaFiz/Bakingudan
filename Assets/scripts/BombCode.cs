using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCode : MonoBehaviour
{

    // [Header("Bomb")]


    public KeyCode inputKey = KeyCode.LeftShift;
    public GameObject preBomb; 
    public Transform BombTransform;
    //public Transform player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject Bomb;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(inputKey) && GetComponent<PlatformerPlayerController>().theKing == true) {

            //spawn object
            spawn();
        }
        
    }
    void spawn() {    
        //game object  bomb = make( bombobject, at player position, don't rotate);
        GameObject Bomb = Instantiate(preBomb, BombTransform.position, Quaternion.identity);
    }
}
