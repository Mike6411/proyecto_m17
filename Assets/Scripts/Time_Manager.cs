using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time_Manager : MonoBehaviour
{
    public Text text;
    public float timer;
    private float EndTime;
    private bool finish = false;

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Timer Stuff
        float delta = Time.deltaTime * 1;
        text.text = "Timer: " + Mathf.Round(timer);
        if (finish == false)
        {
            timer += delta;
        }
    }
}
