using System.Collections;
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

    bool grounded = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        robotWalkParamID = Animator.StringToHash("robotWalk");
    }

    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!grounded)
            {
                if (counter < 0)
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

        bool Walk = false;
        //Movement
        if (Input.GetKey(KeyCode.A))
        {
              Walk = true;
            if (rb.velocity.x > -maxX)
            {
                rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
                sr.flipX = true;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
             Walk = true;
            if (rb.velocity.x < maxX)
            {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
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
    void OnCollisionEnter2D()
    {
        grounded = true;
    }
    void OnCollisionExit2D()
    {
        grounded = false;
    }

}
