﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public float timer;
    public GameObject tiempotext;
    private float EndTime;
    private bool finish = false;
    private float delta;
    public Text text;

    private void Start()
    {
        tiempotext = GameObject.FindGameObjectWithTag("Timer");
        text = tiempotext.GetComponent<Text>();
    }
    void Update()
    {
       //delta = Time.deltaTime*10;

       if (finish == false) {
           text.text = "Timer: " + Mathf.Round(timer);
           timer += Time.deltaTime;
       }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            finish = true;
        }
    }
    
}
