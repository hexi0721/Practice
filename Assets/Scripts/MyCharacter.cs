using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacter : MonoBehaviour
{

    public bool Movable;

    CharacterController controller;
    Animator animator;


    void Start()
    {
        Movable = false;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Vector3 speed = Vector3.zero;

        Debug.Log("Movable " + Movable);
        Debug.Log("controller.isGrounded " + controller.isGrounded);

        if ( Movable && controller.isGrounded)
        {
            speed.x = -1.414f;
            
        }
        
        Debug.Log(speed);
        controller.SimpleMove( speed );


    }


    public void CharacterMove()
    {
        Movable = true;
        animator.SetBool("Forward", true);
    }

    public void CharacterStop()
    {
        Movable = false;
        animator.SetBool("Forward", false);
    }

}
