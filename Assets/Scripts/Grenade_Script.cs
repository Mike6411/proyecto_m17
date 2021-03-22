using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject explosion;
    public int timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DelayedExplosion", timer);
    }

    void DelayedExplosion ()
    {
        GameObject newBoom = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
