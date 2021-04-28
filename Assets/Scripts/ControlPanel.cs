using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    bool broken;

    public GameObject puerta;

    void Start()
    {
        broken = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Projectile" && broken == false )
        {
            broken = true;
            //Cambiar sprite por uno roto
            
            //Abrir trampilla
            puerta.SetActive(false);

        }
    }
}
