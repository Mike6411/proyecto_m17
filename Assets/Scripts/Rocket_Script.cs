using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Script : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject newBoom = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
