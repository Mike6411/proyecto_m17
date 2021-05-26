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

    public bool awoken = false;
    public bool awake = false;
    public bool lookingRight = false;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("Looking_Right", lookingRight);

        RangeCheck();

        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }
        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(this.gameObject);
        }
    }


    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
        {
            awake = true;
            awoken = true;
        }
        if (distance > wakeRange)
        {
            awake = false;
            awoken = false;
        }
    }


    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            if (awoken)
            {
                //Derecha
                if (direction.x > 0)
                {
                    GameObject clone;
                    clone = Instantiate(bullet, shootPointRight.transform.position, Quaternion.Euler(0,0,0),null);
                    clone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                    bulletTimer = 0;
                }

                //Izquierda
                if (direction.x < 0)
                {
                    GameObject clone;
                    clone = Instantiate(bullet, shootPointLeft.transform.position, Quaternion.Euler(0, 0, 180), null);
                    clone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                    bulletTimer = 0;
                }

            }
        }
    }
}

