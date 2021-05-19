using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCanvasManager : MonoBehaviour
{
    [SerializeField] Animator starsAnimator;

    public void EndLevel(int stars)
    {
        starsAnimator.SetInteger("Stars", stars);
    }

    public void GoToMenu()
    {
        Debug.LogError("Volver al menu");
    }
    public void Restart()
    {
        Debug.LogError("Volver al menu");
    }
    public void NextLevel()
    {
        Debug.LogError("Volver al menu");
        Game_Manager.Instance.LoadNextScene();
    }
}
