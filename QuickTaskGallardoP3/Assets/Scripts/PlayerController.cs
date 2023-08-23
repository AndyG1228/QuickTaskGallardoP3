using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    public float speed = 3.0f;

    public float upForce = 200f;
    public float horizontal;
    public float vertical;

    public bool isOnGround = true;

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

        Vector2 velocity = new Vector2(horizontal * speed, rigidbody2d.velocity.y);

        // Move the object
        rigidbody2d.velocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rigidbody2d.AddForce(Vector3.up * upForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

        }
    }

}