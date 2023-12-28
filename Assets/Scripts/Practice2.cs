using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Practice2 : MonoBehaviour
{
    CharacterController controller;
    Animator anim;

    bool IsFW, IsBK, IsLT, IsRT , IsJump , IsFall;
    
    private Vector3 playerVelocity , speed;
    
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        IsFW = false;
        IsBK = false;
        IsLT = false;
        IsRT = false;
        IsJump = false;
        IsFall = false;
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

        
        
        // Changes the height position of the player
        playerVelocity.y += gravityValue * Time.deltaTime;

        if (playerVelocity.y < 0)
            controller.Move((playerVelocity + move) * Time.deltaTime * playerSpeed);
        else
            controller.Move((playerVelocity + move) * Time.deltaTime);

        Debug.Log(controller.isGrounded);
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            IsJump = false;

            
            if (IsFall)
            {
                anim.SetBool("Fall", false);
                anim.SetTrigger("Land");
                IsFall = false;
            }
                
        }

        if (!IsJump && playerVelocity.y < -0.1f)
        {
            anim.SetBool("Fall", true);
            IsFall = true;
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            anim.SetTrigger("Jump");
            IsJump = true;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            
        }

        
        


        //controller.SimpleMove(speed);
    }

    void Action()
    {
        speed = Vector3.zero;

        if (Input.GetKey(KeyCode.W) && IsBK == false) // 前進
        {
            IsFW = true;
            anim.SetBool("Forward", true);

            if (Input.GetKey(KeyCode.A) && IsRT == false) // 左走;
            {

                anim.SetFloat("Direction", -1);
                anim.SetBool("Left", true);
                speed.x = -1 / 1.414f;
                speed.z = 1 / 1.414f;

                IsLT = true;

            }
            else if (Input.GetKey(KeyCode.D) && IsLT == false) // 右走
            {

                anim.SetFloat("Direction", 1);
                anim.SetBool("Right", true);
                speed.x = 1 / 1.414f;
                speed.z = 1 / 1.414f;
                IsRT = true;

            }
            else
            {
                speed.z = 1.0f;
            }




        }
        else if (Input.GetKey(KeyCode.S) && IsFW == false) // 後退
        {
            IsBK = true;
            anim.SetBool("Backward", true);

            if (Input.GetKey(KeyCode.A) && IsRT == false) // 左走;
            {

                anim.SetFloat("Direction", -1);
                anim.SetBool("Left", true);
                speed.x = -1 / 1.414f;
                speed.z = -1 / 1.414f;
                IsLT = true;

            }
            else if (Input.GetKey(KeyCode.D) && IsLT == false) // 右走
            {

                anim.SetFloat("Direction", 1);
                anim.SetBool("Right", true);
                speed.x = 1 / 1.414f;
                speed.z = -1 / 1.414f;
                IsRT = true;

            }
            else
            {
                speed.z = -1.0f;
            }
        }

        if (Input.GetKey(KeyCode.A) && IsRT == false && IsFW == false && IsBK == false) // 左走;
        {

            anim.SetFloat("Direction", -1);
            anim.SetBool("Left", true);
            speed.x = -1.0f;
            IsLT = true;
        }

        if (Input.GetKey(KeyCode.D) && IsLT == false && IsFW == false && IsBK == false) // 右走
        {

            anim.SetFloat("Direction", 1);
            anim.SetBool("Right", true);
            speed.x = 1.0f;
            IsRT = true;

        }




    }
}
