using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Practice2 : MonoBehaviour
{
    public float tmp;

    CharacterController controller;
    Animator anim;

    float waiting = 0f;

    bool IsJump , IsFall , IsGround;
    
    private Vector3 playerVelocity;
    
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        
        IsJump = false;
        IsFall = false;
        IsGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        
        if (move != Vector3.zero)
        {
            transform.forward = move;
            anim.SetBool("Forward", true);
        }
        else
        {
            anim.SetBool("Forward", false);
        }



        playerVelocity.y += gravityValue * Time.deltaTime;

        if (IsFall || IsJump)
        {
            Debug.Log(1);
            controller.Move((move + playerVelocity) * Time.deltaTime);
        }
        else
        {
            Debug.Log(2);
            controller.Move((move + playerVelocity) * Time.deltaTime * playerSpeed);
        }

        if(waiting >= 0)
        {
            waiting -= Time.deltaTime;
        }
        
        

        CheckGround();
        CheckFall();

        Debug.Log(waiting);
        if (Input.GetKeyDown(KeyCode.Space) && IsGround && waiting <= 0)
        {
            anim.SetTrigger("Jump");
            IsJump = true;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

            waiting = 1.74f;
        }
        

        

    }

    

    private void CheckGround()
    {


        IsGround = Physics.Raycast(transform.position + Vector3.up, Vector3.down, 1.1f);

        
        if (IsGround)
        {
            playerVelocity.y = 0f;
            IsJump = false;
        }

        if (IsFall && IsGround)
        {
            anim.SetTrigger("Land");
        }

    }

    private void CheckFall()
    {

        if (playerVelocity.y < -2f && !IsGround && !IsJump)
        {
            IsFall = true;
            anim.SetBool("Fall", true);
        }
        else
        {
            IsFall = false;
            anim.SetBool("Fall", false);
        }
    }
}
