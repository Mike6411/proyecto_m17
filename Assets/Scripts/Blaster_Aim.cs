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
    private AudioManager am;

    public float shotDelay = 0.5f;
    public float elapsedTime = 0;

    void Start()
    {
        elapsedTime = 1f;
        currentWeapon = Weapons.NONE;
        am = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        //Rotation Call
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

        //Shot delay stuff
        elapsedTime += Time.deltaTime;

        //Weapon Use
        if (Input.GetKeyDown(KeyCode.Mouse0) && elapsedTime >= shotDelay)
        {
            if (currentWeapon == Weapons.WPN1)
            {
                elapsedTime = 0;
                GameObject newRocket = Instantiate(rocket, transform.position + transform.right, transform.rotation);
                newRocket.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * rocketSpeed);
                if (am != null)
                {
                    am.Play("RocketLauncher");
                }
            }
            if (currentWeapon == Weapons.WPN2)
            {
                elapsedTime = 0;
                GameObject newC4 = Instantiate(C4, transform.position + transform.right, transform.rotation);
                newC4.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * C4Speed);
                if (am != null)
                {
                    am.Play("C4");
                }
            }
            if (currentWeapon == Weapons.WPN3)
            {
                elapsedTime = 0;
                GameObject newGrenade = Instantiate(grenade, transform.position + transform.right, transform.rotation);
                newGrenade.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * GrenadeSpeed);
                if (am != null)
                {
                    am.Play("GrenadeLauncher");
                }
            }
            if (currentWeapon == Weapons.WPN4)
            {
                elapsedTime = 0;
                GameObject newMine = Instantiate(mine, transform.position + transform.right, transform.rotation);
                newMine.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * MineSpeed);
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
