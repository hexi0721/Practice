using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    CharacterController controller;
    Vector3 speed;

    float JumpCurveTime = 0;
    Animator anim;

    public AnimationCurve Curve; // 配合跳躍高度
    CapsuleCollider col;
    

    bool IsFW, IsBK, IsLT, IsRT, IsQ, IsE;

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
    //static int TalkState = Animator.StringToHash("Base Layer.Talk");

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
        

        IsFW = false;
        IsBK = false;
        IsLT = false;
        IsRT = false;
        IsQ = false;
        IsE = false;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v); // 判斷為走路或跑步 

        speed = Vector3.zero;

        CurrentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        if ((CurrentBaseState.fullPathHash == Idle01State || CurrentBaseState.fullPathHash == toIdle01State || CurrentBaseState.fullPathHash == Idle02State || CurrentBaseState.fullPathHash == toIdle02State ||
            CurrentBaseState.fullPathHash == Forward || CurrentBaseState.fullPathHash == Backward || CurrentBaseState.fullPathHash == Right || CurrentBaseState.fullPathHash == Left))
        {
            JumpCurveTime = 0;
            Action();

            if (Input.GetKeyDown(KeyCode.Space)) // 跳躍
            {

                


                anim.SetTrigger("Jump");


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


        if (Input.GetKeyUp(KeyCode.W)) { IsFW = false; anim.SetBool("Forward", false); anim.SetFloat("Speed", 0); }
        if (Input.GetKeyUp(KeyCode.S)) { IsBK = false; anim.SetBool("Backward", false); anim.SetFloat("Speed", 0); }
        if (Input.GetKeyUp(KeyCode.A) && IsRT == false) { IsLT = false; anim.SetBool("Left", false); anim.SetFloat("Direction", 0); }
        if (Input.GetKeyUp(KeyCode.D) && IsLT == false) { IsRT = false; anim.SetBool("Right", false); anim.SetFloat("Direction", 0); }
        if (Input.GetKeyUp(KeyCode.Q)) { IsQ = false; }
        if (Input.GetKeyUp(KeyCode.E)) { IsE = false; }
    }


    void Action()
    {
        Debug.Log(controller.isGrounded);
        if (controller.isGrounded)
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
                    speed.z = 1.414f;
                    
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
                    speed.z = -1.414f;
                }


            }

            if (Input.GetKey(KeyCode.A) && IsRT == false && IsFW == false && IsBK == false) // 左走;
            {

                anim.SetFloat("Direction", -1);
                anim.SetBool("Left", true);
                speed.x = -1.414f;
                IsLT = true;

            }

            if (Input.GetKey(KeyCode.D) && IsLT == false && IsFW == false && IsBK == false) // 右走
            {

                anim.SetFloat("Direction", 1);
                anim.SetBool("Right", true);
                speed.x = 1.414f;
                IsRT = true;

            }

            
        }

        controller.SimpleMove(speed);

    }
}
