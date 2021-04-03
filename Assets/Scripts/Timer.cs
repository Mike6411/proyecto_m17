using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    public float timer;
    private float EndTime;
    private bool finish = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       float delta = Time.deltaTime*1000;

       if (finish == false) {
           timer += delta;
       }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            finish = true;
        }
    }
    
}
