using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance { get; private set; }
    public Scene currentScene;
    public float timer;
    private float EndTime;
    private bool finish = false;
    public float aux;
    public float time1;
    public float time2;
    public float time3;
    public float time4;
    public float time5;
    public float time6;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;

        if (finish == false)
        {
            timer += delta;
        }
        if (finish == true)
        {
            for (int i = 0; i < 5;)
            {
                if ( i == 0)
                {
                    time1 = timer;
                }
                if (i == 1)
                {
                    time2 = timer;
                }
                if (i == 2)
                {
                    time3 = timer;
                }
                if (i == 3)
                {
                    time4 = timer;
                }
                if (i == 4)
                {
                    time5 = timer;
                }
                if (i == 5)
                {
                    time6 = timer;
                }
                i++;
                finish = false;
            }
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        timer = 0;
        finish = true;
    }
}
