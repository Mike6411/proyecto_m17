using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool GameIsPause = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {

                ContinueGame();
            }
            else {
                Pause();
            
            }
        
        }
       
    }

    public void Pause()
    {
        bool isActive = pauseMenu.activeSelf;
        pauseMenu.SetActive(!isActive);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void ContinueGame() {
        bool isActive = pauseMenu.activeSelf;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

     public void ReturnToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menú");
       
     }
    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
