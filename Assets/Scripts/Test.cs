using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float power;
    public float radius;
    public float timer;
    private float TTL = 200;

   void Update()
    {
        float delta = Time.deltaTime * 1000;
        TTL -= delta;
        if (TTL <= 0)
        {
            Destroy(gameObject);
        }
    }

    
    void AddExplosionForce(Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Impulse)
    {
        Vector2 explosionDir = rb.position - explosionPosition;
        float explosionDistance = explosionDir.magnitude;

        // Normalize without computing magnitude again
        if (upwardsModifier == 0)
        {
            explosionDir /= explosionDistance;
        }
        else
        {
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        //rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);

        rb.AddForce(explosionForce * explosionDir, mode);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(rb);
        if (rb != null)
        {
            AddExplosionForce(rb, power, transform.position);
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
