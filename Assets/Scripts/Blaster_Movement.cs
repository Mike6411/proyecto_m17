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
       
        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > -maxX)
            {
                rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
                bool isWalking = animator.GetBool(robotWalkParamID);
                animator.SetBool(robotWalkParamID, true);
            }
                

        }
        else {
            bool isWalking = animator.GetBool(robotWalkParamID);
            animator.SetBool(robotWalkParamID, false);
        }


        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < maxX)
            {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
                bool isWalking = animator.GetBool(robotWalkParamID);
                animator.SetBool(robotWalkParamID, true);
            }

        }
        else {
            bool isWalking = animator.GetBool(robotWalkParamID);
            animator.SetBool(robotWalkParamID, false);
        }



    }

    void FixedUpdate()
    {
        //float movingSpeedR = rb.velocity.x + speed;
        //float movingSpeedL = rb.velocity.x - speed;

        //Scene reset
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("Next_Level");
        }

        //Left Right Movement
      /*  if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > -maxX)
            {
                rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
                  bool isWalking = animator.GetBool(robotWalkParamID);
                  animator.SetBool(robotWalkParamID, true);
            }
          
        }


        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < maxX)
            {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
                 bool isWalking = animator.GetBool(robotWalkParamID);
                 animator.SetBool(robotWalkParamID, true);
            }
           
        }*/
 

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
