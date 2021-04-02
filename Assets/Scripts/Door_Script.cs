using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door_Script : MonoBehaviour
{
    public GameObject PressurePlate;
    public bool Opened = true;

    void Start (){
       
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Opened == true)
        {
            if ( collision.gameObject.tag == "Player")
            {
                Game_Manager.Instance.LoadNextScene();
            }
        }
    }
}
