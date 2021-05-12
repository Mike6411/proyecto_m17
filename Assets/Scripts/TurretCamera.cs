using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCamera : MonoBehaviour
{
    public float range;
    private Transform target;
    bool detected = false;
    Vector2 direction;
    public GameObject gun;
   
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,direction,range);
        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if (detected == false)
                {
                    detected = true;
                }
            }
            else
            {
                if (detected == true)
                {
                    detected = false;
                }
            }
        }
        if (detected)
        {
            gun.transform.up = direction;          
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
