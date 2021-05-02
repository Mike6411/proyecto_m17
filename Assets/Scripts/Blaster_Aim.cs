using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster_Aim : MonoBehaviour
{
    private int maxAngle = 90;
    public GameObject jugador;
    public GameObject rocket;
    public GameObject C4;
    public GameObject grenade;
    public GameObject mine;
    public float rocketSpeed;
    public float C4Speed;
    public float GrenadeSpeed;
    public float MineSpeed;
    public SpriteRenderer sr;
    public enum Weapons { NONE, WPN1, WPN2, WPN3, WPN4 };
    public Weapons currentWeapon;
    public Sprite rl;
    public Sprite c4l;
    public Sprite gl;
    public Sprite ml;
    public Sprite empty;

    public bool canShoot;
    private float cooldown = 0;

    void Start()
    {
        currentWeapon = Weapons.NONE;
        canShoot = true;
    }

    void Update()
    {
        //Rotation Call
        float delta = Time.time * 1000;
        RotationWeapon(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //Weapon Select
        if (Input.GetKey(KeyCode.Alpha1))
        {
            currentWeapon = Weapons.WPN1;
            sr.sprite = rl;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            currentWeapon = Weapons.WPN2;
            sr.sprite = c4l;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            currentWeapon = Weapons.WPN3;
            sr.sprite = gl;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            currentWeapon = Weapons.WPN4;
            sr.sprite = ml;
        }
        if (Input.GetKey(KeyCode.Alpha0))
        {
            currentWeapon = Weapons.NONE;
            sr.sprite = empty;
        }

        //Weapon Use
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentWeapon == Weapons.WPN1 && canShoot)
            {
                GameObject newRocket = Instantiate(rocket, transform.position + transform.right, transform.rotation);
                newRocket.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * rocketSpeed);
                FindObjectOfType<AudioManager>().Play("RocketLauncher");
                canShoot = false;
            }
            if (currentWeapon == Weapons.WPN2 && canShoot)
            {
                GameObject newC4 = Instantiate(C4, transform.position + transform.right, transform.rotation);
                newC4.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * C4Speed);
                FindObjectOfType<AudioManager>().Play("C4");
                canShoot = false;
            }
            if (currentWeapon == Weapons.WPN3 && canShoot)
            {
                GameObject newGrenade = Instantiate(grenade, transform.position + transform.right, transform.rotation);
                newGrenade.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * GrenadeSpeed);
                 FindObjectOfType<AudioManager>().Play("GrenadeLauncher");
                canShoot = false;
            }
            if (currentWeapon == Weapons.WPN4 && canShoot)
            {
                GameObject newMine = Instantiate(mine, transform.position + transform.right, transform.rotation);
                newMine.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * MineSpeed);
                canShoot = false;
            }
        }
        //Weapon Delay
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (currentWeapon == Weapons.WPN1)
            {
                cooldown += delta;
                if (cooldown > 10000)
                {
                    canShoot = true;
                    cooldown = 0;
                }
            }
            if (currentWeapon == Weapons.WPN2)
            {
                cooldown += delta;
                if (cooldown > 10000)
                {
                    canShoot = true;
                    cooldown = 0;
                }
            }
            if (currentWeapon == Weapons.WPN3)
            {
                cooldown += delta;
                if (cooldown > 10000)
                {
                    canShoot = true;
                    cooldown = 0;
                }
            }
            if (currentWeapon == Weapons.WPN4)
            {
                cooldown += delta;
                if (cooldown > 10000)
                {
                    canShoot = true;
                    cooldown = 0;
                }
            }
        }
    }

    public void RotationWeapon(Vector3 mousePos)
    {
        Vector2 dir = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (rotationZ <= -maxAngle)
        { 
            sr.flipY = true;
        }
        else if (rotationZ >= maxAngle)
        {
            
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }

        transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
    }

}
