using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Practice2 : MonoBehaviour
{
    CharacterController controller;
    Animator anim;

    bool IsFW, IsBK, IsLT, IsRT;
    Vector3 speed;

    
    private Vector3 playerVelocity;
    
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded && playerVelocity.y < 0)
        {

            playerVelocity.y = 0;

        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);



        if (move != Vector3.zero)
        {
            transform.forward = move;
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        // Changes the height position of the player..
        Debug.Log(controller.isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        
        
        

        




        /*if (Input.GetKeyUp(KeyCode.W)) { IsFW = false; anim.SetBool("Forward", false); anim.SetFloat("Speed", 0); }
        if (Input.GetKeyUp(KeyCode.S)) { IsBK = false; anim.SetBool("Backward", false); anim.SetFloat("Speed", 0); }
        if (Input.GetKeyUp(KeyCode.A) && IsRT == false) { IsLT = false; anim.SetBool("Left", false); anim.SetFloat("Direction", 0); }
        if (Input.GetKeyUp(KeyCode.D) && IsLT == false) { IsRT = false; anim.SetBool("Right", false); anim.SetFloat("Direction", 0); }
        if (Input.GetKeyUp(KeyCode.Q)) { IsQ = false; }
        if (Input.GetKeyUp(KeyCode.E)) { IsE = false; }*/

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
