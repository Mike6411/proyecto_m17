using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster_Movement : MonoBehaviour
{

    public float speed;
    public float jump;
    public Rigidbody2D rb;
    public GameObject rocket;
    public float rocketSpeed;
    public enum Weapons { NONE, WPN1, WPN2, WPN3, WPN4};
    public Weapons currentWeapon;

    float moveVelocity;

    bool grounded = true;

    void Start()
    {
        currentWeapon = Weapons.NONE;
    }

    void Update()
    {
        //Weapon Select
        if (Input.GetKey(KeyCode.Alpha1))
        {
            currentWeapon = Weapons.WPN1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            currentWeapon = Weapons.WPN2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            currentWeapon = Weapons.WPN3;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            currentWeapon = Weapons.WPN4;
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                /*
                rb.velocity = new Vector2(rb.velocity.x, jump);
                */
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

        //Weapon Use
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentWeapon == Weapons.WPN1)
            {
                GameObject newRocket = Instantiate(rocket, transform.position + transform.right, transform.rotation);
                newRocket.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * rocketSpeed);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentWeapon == Weapons.WPN1)
            {
                GameObject newRocket = Instantiate(rocket, transform.position - transform.right, transform.rotation);
                newRocket.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * rocketSpeed);
            }
        }
    }
    //Check if Grounded
    void OnTriggerEnter2D()
    {
        grounded = true;
    }
    void OnTriggerExit2D()
    {
        grounded = false;
    }

}
