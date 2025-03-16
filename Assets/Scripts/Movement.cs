using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontalMove;
    float verticalMove;

    Rigidbody2D player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");


    }
    private void FixedUpdate()
    {
        player.velocity = new Vector2(horizontalMove * speed, verticalMove * speed);

    }


}
