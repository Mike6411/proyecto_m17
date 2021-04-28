using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript2 : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;
    bool dead;

    public SpriteRenderer sr;
    private Animator animator;
    private int torretdeathParamID;
    bool TorretD;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        torretdeathParamID = Animator.StringToHash("torreta_death");
        TorretD = false;
        sr = GetComponent<SpriteRenderer>();
        dead = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);
        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        }
        if (!dead)
        {
            if (Detected)
            {
                Gun.transform.up = Direction;
                if (Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1 / FireRate;
                    shoot();
                }
            }
        }
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        FindObjectOfType<AudioManager>().Play("RocketLauncher");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TorretD = animator.GetBool(torretdeathParamID);
            animator.SetBool(torretdeathParamID, true);

        }
        dead = true;
    }
}