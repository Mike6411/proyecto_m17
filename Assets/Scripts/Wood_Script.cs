using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Script : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            Destroy(this.gameObject);
        }
    }
}
