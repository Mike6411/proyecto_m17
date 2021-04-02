using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject explosion;
    public bool primed;
    public bool tripped;

    // Start is called before the first frame update
    void Start()
    {
        primed = false;
    }

    void Update()
    {
        if(primed == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.TransformDirection(Vector2.up*0.1f), transform.TransformDirection(Vector2.up), 1f);
            if (hit)
            {
                
                GameObject newBoom = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 10;
        Gizmos.DrawRay(transform.position, direction);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb.bodyType = RigidbodyType2D.Static;
        primed = true;
    }
}
