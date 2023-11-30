using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimation : MonoBehaviour
{
    
    Animator anim;

    bool IsFW, IsBK, IsLT, IsRT , IsQ , IsE;

    private void Start()
    {

        anim = GetComponent<Animator>();
        
        IsFW = false;
        IsBK = false;
        IsLT = false;
        IsRT = false;
        IsQ = false;
        IsE = false;


    }

    void Update()
    {
        
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v); // 判斷為走路或跑步 

        //float h = Input.GetAxis("Horizontal");
        //anim.SetFloat("Direction", h);


        if (Input.GetKey(KeyCode.Q) && IsE == false)
        {
            IsQ = true;
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), -60 * Time.deltaTime );
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

            transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);

        }
        else if (Input.GetKey(KeyCode.S) && IsFW == false) // 後退
        {
            IsBK = true;
            anim.SetBool("Backward", true);

        }

        if (Input.GetKey(KeyCode.A) && IsRT == false) // 左走;
        {
            
            anim.SetFloat("Direction", -1);
            anim.SetBool("Left" , true);

            IsLT = true;
            
        }
        
        if (Input.GetKey(KeyCode.D) && IsLT == false) // 右走
        {
            
            anim.SetFloat("Direction", 1);
            anim.SetBool("Right", true);

            IsRT = true;
            
        }


        if(Input.GetKeyUp(KeyCode.W)) { IsFW = false; anim.SetBool("Forward", false); anim.SetFloat("Speed", 0); }
        if (Input.GetKeyUp(KeyCode.S)) { IsBK = false; anim.SetBool("Backward", false); anim.SetFloat("Speed", 0); }
        if(Input.GetKeyUp(KeyCode.A) && IsRT == false ) { IsLT = false; anim.SetBool("Left", false); anim.SetFloat("Direction", 0); }
        if (Input.GetKeyUp(KeyCode.D) && IsLT == false) {  IsRT = false; anim.SetBool("Right", false); anim.SetFloat("Direction", 0); }
        if (Input.GetKeyUp(KeyCode.Q)) { IsQ = false; }
        if (Input.GetKeyUp(KeyCode.E)) { IsE = false; }



    }
}
