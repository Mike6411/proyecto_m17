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
    public float rocketSpeed;
    public float C4Speed;
    public float GrenadeSpeed;
    public SpriteRenderer sr;
    public enum Weapons { NONE, WPN1, WPN2, WPN3, WPN4 };
    public Weapons currentWeapon;

    void Start()
    {
        currentWeapon = Weapons.NONE;
    }

    void Update()
    {
        //Rotation Call
        RotationWeapon(Camera.main.ScreenToWorldPoint(Input.mousePosition));

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
        if (Input.GetKey(KeyCode.Alpha0))
        {
            currentWeapon = Weapons.NONE;
        }

        //Weapon Use
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentWeapon == Weapons.WPN1)
            {
                GameObject newRocket = Instantiate(rocket, transform.position + transform.right, transform.rotation);
                newRocket.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * rocketSpeed);
            }
            if (currentWeapon == Weapons.WPN2)
            {
                GameObject newC4 = Instantiate(C4, transform.position + transform.right, transform.rotation);
                newC4.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * C4Speed);
            }
            if (currentWeapon == Weapons.WPN3)
            {
                GameObject newGrenade = Instantiate(grenade, transform.position + transform.right, transform.rotation);
                newGrenade.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * GrenadeSpeed);
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
