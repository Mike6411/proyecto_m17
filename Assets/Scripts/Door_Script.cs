using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Script : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Final_Prototipo");
        }
    }
}
