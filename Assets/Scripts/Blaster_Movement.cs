using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            }
            else
            {
                rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
                counter = 0;
            }
        }

        moveVelocity = 0;

        //Scene reset
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("Next_Level");
        }

        //Left Right Movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveVelocity = speed;
        }

        //Cambiar el moveVelocity

        rb.velocity = new Vector2(rb.velocity.x + moveVelocity, rb.velocity.y);
    }
    //Check if Grounded
    void OnCollisionEnter2D()
    {
        grounded = true;
    }
    void OnCollisionExit2D()
    {
        grounded = false;
    }

}
