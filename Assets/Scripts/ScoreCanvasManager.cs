using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCanvasManager : MonoBehaviour
{
    [SerializeField] Animator starsAnimator;
    public Text score;
    public GameObject tiempotext;

    private void Start()
    {
        tiempotext = GameObject.FindGameObjectWithTag("Score");
        score = tiempotext.GetComponent<Text>();
    }

    public void EndLevel(int stars)
    {
        starsAnimator.SetInteger("Stars", stars);
    }

    public void GoToMenu()
    {
        Debug.LogError("Volver al menu");
        SceneManager.LoadScene("Main_Menú");
    }
    public void Restart()
    {
        Debug.LogError("Reiniciar nivel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        Debug.LogError("Siguiente nivel");
        Game_Manager.Instance.LoadNextScene();
    }
}
