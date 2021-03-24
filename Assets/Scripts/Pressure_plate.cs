using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_plate : MonoBehaviour
{
    GameObject puerta;
    //puclic Animator pressure_plate;
    //public Animator door;

    void OnTriggerEnter(Collider col)
    {
        //pressure_plate.SetBool ("ON", false);
        //door.SetBool ("open", false);
    }

    void Update()
    {
        //pressure_plate.SetBool ("ON", true);
        //door.SetBool ("open", true);
    }
}
