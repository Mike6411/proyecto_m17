using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door_Script : MonoBehaviour
{
    public bool Opened = true;
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] Timer timer;
    public float twoStars = 0;
    public float threeStars = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Opened == true)
        {
            if ( collision.gameObject.tag == "Player")
            {
                
                scoreCanvas.SetActive(true);
                if (timer.timer < threeStars)
                {
                    scoreCanvas.GetComponent < ScoreCanvasManager > ().EndLevel(3);
                }else if (timer.timer < twoStars) 
                {
                    scoreCanvas.GetComponent < ScoreCanvasManager > ().EndLevel(2);
                }else
                {
                    scoreCanvas.GetComponent < ScoreCanvasManager > ().EndLevel(1);
                }
            }
        }
    }
}
