using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject explosion;
    public bool primed;

    // Start is called before the first frame update
    void Start()
    {
        primed = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && primed){
            GameObject newBoom = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb.bodyType = RigidbodyType2D.Static;
        primed = true;
    }
}
