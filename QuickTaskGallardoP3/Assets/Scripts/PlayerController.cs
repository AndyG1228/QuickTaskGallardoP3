using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    public float speed = 3.0f;

    public float upForce = 200f;
    public float horizontal;
    public float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (Input.GetMouseButtonDown(0))
        {
            
            rigidbody2d.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        //Create the movement vector
        Vector2 position = rigidbody2d.position;

        //Changing the x and y position
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        //Set the updated position
        rigidbody2d.MovePosition(position);
    }
}