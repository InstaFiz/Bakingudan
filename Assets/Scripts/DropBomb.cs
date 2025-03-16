using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform DropPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("LeftShift"))
            Instantiate(bombPrefab, DropPos.position, Quaternion.identity);
    }

}
