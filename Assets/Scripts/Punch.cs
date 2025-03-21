using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{


    public KeyCode inputKey = KeyCode.Q;
    public GameObject fist; // Bomb prefab
    public Transform fistSpawn; // Where the fist is held before throwing
    private PlatformerPlayerController playerController;
    public float throwForce = 10f;
    //private GameObject puncher = null;


    // Start is called before the first frame update
    void Start()
    {
       // playerController = GetComponent<PlatformerPlayerController>();
    }

    // Update is called once per frame
    void Update()


    {


      //  if (Input.GetKeyDown(inputKey))
        {
          //  punch();


        }

    }

    void punch() {
        //  puncher =Instantiate(fist, fistSpawn.position, Quaternion.identity);
       // Instantiate(fist, fistSpawn.position, Quaternion.identity);
       //// Rigidbody2D punchThr = fist.GetComponent<Rigidbody2D>();
       // punchThr.velocity = new Vector2(transform.localScale.x * throwForce, 5f);


    }
}
