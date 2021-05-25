using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    private static Game_Manager instance = null;

     // Game Instance Singleton
     public static Game_Manager Instance
     {
         get
         { 
             if (instance == null)
                {
                 instance = FindObjectOfType<Game_Manager>();
                }
             if (instance == null)
                {
                 Debug.LogError("Singleton<" + typeof(Game_Manager) + "> instance has been not found.");
                 GameObject go = new GameObject();
                 go.AddComponent<Game_Manager>();
                 instance = go.GetComponent < Game_Manager > ();
                 
                }
             return instance; 
         }
     }

    public Scene currentScene;
    public Text text;
    public float timer;
    private int activeScene;
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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Timer Stuff
        float delta = Time.deltaTime * 1;
        text.text = "Timer: " + timer;
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
                timer = 0;
                finish = false;
            }
        }

        //Pasar de nivel
        if (Input.GetKeyDown(KeyCode.O)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

  

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        timer = 0;
        finish = true;
    }
}
