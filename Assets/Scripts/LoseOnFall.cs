using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnFall : MonoBehaviour
{
    public float lowestY;

    public GameObject crown;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < lowestY)
        {
            transform.position = new Vector3(-2.62f, 0.9f, 0f);
            GetComponent<PlatformerPlayerController>().health -= 100;
            if (GetComponent<PlatformerPlayerController>().theKing == true) {
                GetComponent<PlatformerPlayerController>().theKing = false;
                crown.GetComponent<CrownScript>().active = true;
            }
        }
    }
}
