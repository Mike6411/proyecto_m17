﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blaster_Movement : MonoBehaviour
{

    public float speed;
    public float jump;
    private float speedx;
    public Rigidbody2D rb;
    private int counter = 0;
    public float maxX = 5;
    private Animator animator;
    private int robotWalkParamID;
    public SpriteRenderer sr;

    float moveVelocity;

    public bool grounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
        robotWalkParamID = Animator.StringToHash("robotWalk");
    }

    void Update()
    {
        float delta = Time.fixedDeltaTime;

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded) {
                rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            }
        }

        bool Walk = false;
        //Movement
        if (Input.GetKey(KeyCode.A))
        {
            Walk = true;

            if (rb.velocity.x > -maxX)
            {
                //rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
                rb.velocity += new Vector2(-speed, 0);
                sr.flipX = true;
            }
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            Walk = true;

            if (rb.velocity.x < maxX)
            {
                //rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
                rb.velocity += new Vector2(speed,0);
                sr.flipX = false;
            }
        }
        //Animator
        if (Walk)
        {
            Walk = animator.GetBool(robotWalkParamID);
            animator.SetBool(robotWalkParamID, true);
        }
        else {
            Walk = animator.GetBool(robotWalkParamID);
            animator.SetBool(robotWalkParamID, false);
        }
    }

    void FixedUpdate()
    {
        //Scene reset
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    //Check if Grounded
    void OnCollisionStay2D()
    {
        grounded = true;
    }
    void OnCollisionExit2D()
    {
        grounded = false;
    }

}
