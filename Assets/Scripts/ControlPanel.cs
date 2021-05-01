using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    bool broken;

    public GameObject puerta;
    private Animator animator;
    private int panelRotoParamID;

    void Start()
    {
        broken = false;
        animator = GetComponent<Animator>();
        panelRotoParamID = Animator.StringToHash("panel_roto");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Projectile" && broken == false )
        {
            broken = true;
            //Cambiar sprite por uno roto
            bool isBroken = animator.GetBool(panelRotoParamID);
            animator.SetBool(panelRotoParamID, true);

            //Abrir trampilla
            puerta.SetActive(false);

        }
    }
}
