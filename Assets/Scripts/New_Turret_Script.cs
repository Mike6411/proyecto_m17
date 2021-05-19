using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Turret_Script : MonoBehaviour
{
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    public bool awake = false;
    public bool lookingRight = false;


     void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

     void Start()
    {
        
    }

    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("Looking_Right", lookingRight);

        RangeCheck();

        if(target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }
        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }
    }


    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance < wakeRange)
        {
            awake = true;
        }
        if(distance > wakeRange)
        {
            awake = false;
        }
    }


    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (!attackingRight)
            {
                GameObject clone;
                clone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation);
                clone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }

            if (attackingRight)
            {
                GameObject clone;
                clone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation);
                clone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }

        }
    }
}

