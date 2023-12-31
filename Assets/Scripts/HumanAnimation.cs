using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HumanAnimation : MonoBehaviour
{
    

    float jumpHeight = 5.0f;
    float JumpCurveTime = 0;
    
    public AnimationCurve Curve; // 配合跳躍高度
    CapsuleCollider col;
    Rigidbody rb;

    bool IsFW, IsBK, IsLT, IsRT , IsQ , IsE , IsGround , IsJump ,IsFall;

    Animator anim;
    AnimatorStateInfo CurrentBaseState;

    static int Idle01State = Animator.StringToHash("Base Layer.Idle01");
    static int toIdle02State = Animator.StringToHash("Base Layer.toIdle02");
    static int Idle02State = Animator.StringToHash("Base Layer.Idle02");
    static int toIdle01State = Animator.StringToHash("Base Layer.toIdle01");
    static int Forward = Animator.StringToHash("Base Layer.Forward");
    static int Backward = Animator.StringToHash("Base Layer.Backward");
    static int Right = Animator.StringToHash("Base Layer.Right");
    static int Left = Animator.StringToHash("Base Layer.Left");
    static int JumpState = Animator.StringToHash("Base Layer.Jump");


    private void Start()
    {


        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();

        IsFW = false;
        IsBK = false;
        IsLT = false;
        IsRT = false;
        IsQ = false;
        IsE = false;
        IsGround = false;
        IsJump = false;
        IsFall = false;

    }

    void Update()
    {
        CurrentBaseState = anim.GetCurrentAnimatorStateInfo(0); // 得在Update裡
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v); // 判斷為走路或跑步 

        //float h = Input.GetAxis("Horizontal");
        //anim.SetFloat("Direction", h);

        CheckGround();
        CheckFall();
        

        if ((CurrentBaseState.fullPathHash == Idle01State || CurrentBaseState.fullPathHash == toIdle01State || CurrentBaseState.fullPathHash == Idle02State || CurrentBaseState.fullPathHash == toIdle02State ||
            CurrentBaseState.fullPathHash == Forward || CurrentBaseState.fullPathHash == Backward || CurrentBaseState.fullPathHash == Right || CurrentBaseState.fullPathHash == Left))
        {
            
            JumpCurveTime = 0;
            Action();


            if (Input.GetKeyDown(KeyCode.Space) && IsGround) // 跳躍
            {

                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                anim.SetTrigger("Jump");
                IsJump = true;

            }

            if (Input.GetKeyDown(KeyCode.F)) // 講話
            {
                anim.SetTrigger("Talk");
                
            }

        }
        else if (CurrentBaseState.fullPathHash == JumpState)
        {
            col.height = Curve.Evaluate(JumpCurveTime); // 模型碰撞高度
            col.center = new Vector3(col.center.x, col.height / 2, col.center.z); // 模型碰撞中心 高度/2

            JumpCurveTime += Time.deltaTime;
            
            Action();

        }


        KeyCodeUp();

        
        


    }

    private void CheckFall()
    {
        if (rb.velocity.y < -1f && !IsGround && !IsJump)
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

    private void KeyCodeUp()
    {
        if (Input.GetKeyUp(KeyCode.W)) { IsFW = false; anim.SetBool("Forward", false); anim.SetFloat("Speed", 0); }
        if (Input.GetKeyUp(KeyCode.S)) { IsBK = false; anim.SetBool("Backward", false); anim.SetFloat("Speed", 0); }
        if (Input.GetKeyUp(KeyCode.A) && IsRT == false) { IsLT = false; anim.SetBool("Left", false); anim.SetFloat("Direction", 0); }
        if (Input.GetKeyUp(KeyCode.D) && IsLT == false) { IsRT = false; anim.SetBool("Right", false); anim.SetFloat("Direction", 0); }
        if (Input.GetKeyUp(KeyCode.Q)) { IsQ = false; }
        if (Input.GetKeyUp(KeyCode.E)) { IsE = false; }
    }

    private void CheckGround()
    {
        
        IsGround = Physics.Raycast(transform.position + Vector3.up , Vector3.down , 1.01f);
        if (IsGround)
        {
            IsJump = false;
        }
        
        if (IsFall && IsGround)
        {
            anim.SetTrigger("Land");
        }

    }

    void Action()
    {
        

        if (Input.GetKey(KeyCode.Q) && IsE == false)
        {
            IsQ = true;
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), -60 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E) && IsQ == false)
        {
            IsE = true;
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), 60 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) && IsBK == false) // 前進
        {
            IsFW = true;
            anim.SetBool("Forward", true);

            if (Input.GetKey(KeyCode.A) && IsRT == false) // 左走;
            {

                anim.SetFloat("Direction", -1);
                anim.SetBool("Left", true);
                transform.Translate(new Vector3(-1 / 1.414f, 0, 1 / 1.414f) * Time.deltaTime * 2, Space.Self);
                IsLT = true;

            }
            else if (Input.GetKey(KeyCode.D) && IsLT == false) // 右走
            {

                anim.SetFloat("Direction", 1);
                anim.SetBool("Right", true);
                transform.Translate(new Vector3(1 / 1.414f, 0, 1 / 1.414f) * Time.deltaTime * 2, Space.Self);
                IsRT = true;

            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 2, Space.Self);
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
                transform.Translate(new Vector3(-1 / 1.414f, 0, -1 / 1.414f) * Time.deltaTime, Space.Self);
                IsLT = true;

            }
            else if (Input.GetKey(KeyCode.D) && IsLT == false) // 右走
            {

                anim.SetFloat("Direction", 1);
                anim.SetBool("Right", true);
                transform.Translate(new Vector3(1 / 1.414f, 0, -1 / 1.414f) * Time.deltaTime, Space.Self);
                IsRT = true;

            }
            else
            {
                transform.Translate(Vector3.back * Time.deltaTime, Space.Self);
            }


        }

        if (Input.GetKey(KeyCode.A) && IsRT == false && IsFW == false && IsBK == false) // 左走;
        {

            anim.SetFloat("Direction", -1);
            anim.SetBool("Left", true);
            transform.Translate(Vector3.left * Time.deltaTime * 2, Space.Self);
            IsLT = true;

        }

        if (Input.GetKey(KeyCode.D) && IsLT == false && IsFW == false && IsBK == false) // 右走
        {

            anim.SetFloat("Direction", 1);
            anim.SetBool("Right", true);
            transform.Translate(Vector3.right * Time.deltaTime * 2, Space.Self);
            IsRT = true;

        }


        
        
    }



}
