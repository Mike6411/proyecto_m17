using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //poner aqui la animacion de la puerta y que cuando el botton o la placa sean presionadas o tocadas llamar a la animacion de la puerta
    //para hacer que se active la animacion mientras pongamos un if que colisione con todo con todo ya estaria llamando a la animacion

    private Animator animator;
    private int doorOpenParamID;
    public Rigidbody2D rb;
    bool click;

    // Start is called before the first frame update
    void Start()
    {
        click = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        doorOpenParamID = Animator.StringToHash("doorOpen");
    }

    // Update is called once per frame
    void Update()
    {
        //Button Interaction
        if (click)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                bool isOpen = animator.GetBool(doorOpenParamID);
                animator.SetBool(doorOpenParamID, true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            click = true;
        }
    }
}
