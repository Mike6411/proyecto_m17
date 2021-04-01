using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door_Script : MonoBehaviour
{
    public GameObject PressurePlate;
    private PressureplateScript Pressure_plate;
    public bool Opened = false;
    void Start (){
        Pressure_plate = PressurePlate.GetComponent<Pressure_plate>();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
      if (PressurePlate.IsDoorOpened == true){
        if ( collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Final_Prototipo");
        }
        }
    }
}
