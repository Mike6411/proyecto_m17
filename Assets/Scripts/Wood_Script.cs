using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Script : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Projectile")
        {
            /*
             Aqui pon la animación de romperse
            */
            Destroy(this.gameObject);
        }
    }
}
