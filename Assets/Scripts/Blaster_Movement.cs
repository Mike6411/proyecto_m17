using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster_Movement : MonoBehaviour
{

    public float speed;
    public float jump;
    public Rigidbody2D rb;
    private int counter = 0;

    float moveVelocity;

    bool grounded = true;

    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!grounded)
            {
                if (counter < 1)
                {
                    rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
                    counter++;
                }
                else if (counter >= 1)
                {
                    counter = 0;
                }
            }
            else
            {
                rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            }
        }

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }

        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
    }
    //Check if Grounded
    void OnCollisionStay2D()
    {
        grounded = true;
    }
    

}
