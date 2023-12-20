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

        if ( Movable )
        {
            speed.x = -1.414f;
            
        }
        
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
