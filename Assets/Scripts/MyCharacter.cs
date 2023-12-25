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

        if ( Movable && controller.isGrounded)
        {
            speed.x = -1.414f;
            
        }

        controller.SimpleMove( speed );


    }


    public void CharacterMove()
    {
        animator.SetBool("Forward", true);
        Movable = true;
        
    }

    public void CharacterStop()
    {
        animator.SetBool("Forward", false);
        Movable = false;
        
    }

}
