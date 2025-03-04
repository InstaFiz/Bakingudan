using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject Bomb;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift)) {

            //spawn object
            Instantiate(Bomb, transform.position, Quaternion.identity);
        }
        
    }
}
