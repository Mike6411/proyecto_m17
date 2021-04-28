using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_plate : MonoBehaviour
{
  
  public GameObject door;
  private Animator animator;
    private int doorOpenParamID;
   // public Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        
    //    rb = GetComponent<Rigidbody2D>();
        animator = door.GetComponent<Animator>();
        doorOpenParamID = Animator.StringToHash("doorOpen");
    } 
    
    void OnTriggerStay2D(Collider2D col){
      if (col.gameObject.tag != "Projectile"){
        // bool isOpen = animator.GetBool(doorOpenParamID);
                animator.SetBool(doorOpenParamID, true);
            AudioManager am = FindObjectOfType<AudioManager>();
            if (am != null) { 
                am.Play("OpenDoor");
            }
            
      }
    }

   void OnTriggerExit2D(Collider2D col)
    {
      if (col.gameObject.tag != "Projectile"){
        // bool isOpen = animator.GetBool(doorOpenParamID);
                animator.SetBool(doorOpenParamID, false);
            AudioManager am = FindObjectOfType<AudioManager>();
            if (am != null)
            {
                am.Play("OpenDoor");
            }
        }
                 
    }

 

}
