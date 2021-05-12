using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            bool isActive = pauseMenu.activeSelf;

            pauseMenu.SetActive(!isActive);
        }
    }


    public void ContinueGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     public void ReturnToMainMenu() {
        SceneManager.LoadScene("Main_Menú");
       
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
