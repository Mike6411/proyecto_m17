using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_plate : MonoBehaviour
{
  
  public GameObject door;
  private Animator animator;
    private int doorOpenParamID;
    public Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = door.GetComponent<Animator>();
        doorOpenParamID = Animator.StringToHash("doorOpen");
    }

    
    

    void OnTriggerEnter2D(Collider2D col)
    {
     
         bool isOpen = animator.GetBool(doorOpenParamID);
                animator.SetBool(doorOpenParamID, true);
                 FindObjectOfType<AudioManager>().Play("OpenDoor");
                 
                 
    }
    void OnTriggerExit2D(Collider2D col)
    {
      
         bool isOpen = animator.GetBool(doorOpenParamID);
                animator.SetBool(doorOpenParamID, false);
                 FindObjectOfType<AudioManager>().Play("OpenDoor");
    
                 
    }

 

}
