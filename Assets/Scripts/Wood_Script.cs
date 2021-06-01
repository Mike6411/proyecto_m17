using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Script : MonoBehaviour
{

    public ParticleSystem yep;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            ParticleSystem particle = Instantiate(yep, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
