using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Cone : MonoBehaviour
{
    public New_Turret_Script turretAI;

    public bool isRight = false;

    void Awake()
    {
        turretAI = gameObject.GetComponentInParent<New_Turret_Script>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (isRight)
            {
                turretAI.Attack(false);
            }
            else
            {
                turretAI.Attack(true);
            }
        }
    }
}
