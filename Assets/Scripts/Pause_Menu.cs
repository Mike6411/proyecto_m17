using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public Scene currentScene;
    private int activeScene;
    public static Game_Manager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Menú Pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Guarda la escena en una variable
            activeScene = SceneManager.GetActiveScene().buildIndex;
            //esto deberia sirvir para volver a la antigua escena
            SceneManager.LoadScene(activeScene);
            //Abrir menú pausa
            SceneManager.LoadScene("Options_Menu");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            //esto deberia sirvir para volver a la antigua escena
            SceneManager.LoadScene(activeScene);
        }
    }
}
