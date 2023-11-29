using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimation : MonoBehaviour
{
    public float animspeed = 1.5f;
    Animator anim;

    [SerializeField] Camera cam;

    bool IsFW, IsBK, IsLT, IsRT , IsQ , IsE;

    private void Start()
    {

        anim = GetComponent<Animator>();
        animspeed = anim.GetCurrentAnimatorStateInfo(0).speed;

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
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);


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

        if (Input.GetKey(KeyCode.W) && IsBK == false) // 前進 左前進 右前進
        {
            IsFW = true;


            if (Input.GetKeyDown(KeyCode.A) && IsRT == false)
            {
                IsLT = true;
                transform.Translate(new Vector3(-1 , 0 , 1) * Time.deltaTime * 2, Space.Self);
                anim.SetFloat("Direction", -1);
            }
            else if (Input.GetKeyDown(KeyCode.D) && IsLT == false)
            {
                IsRT = true;
                transform.Translate(new Vector3(1, 0, 1) * Time.deltaTime * 2, Space.Self);
                anim.SetFloat("Direction", 1);

            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 2, Space.Self);
            }

            if ((Input.GetKeyUp(KeyCode.A) && IsRT == false) || (Input.GetKeyUp(KeyCode.D) && IsLT == false))
            {
                anim.SetFloat("Direction", 0);
            }

        }
        else if (Input.GetKey(KeyCode.S) && IsFW == false) // 後退 左後退 右後退
        {
            IsBK = true;

            if (Input.GetKey(KeyCode.A) && IsRT == false)
            {
                IsLT = true;
                anim.SetFloat("Direction", -1);
            }
            else if (Input.GetKey(KeyCode.D) && IsLT == false)
            {
                IsRT = true;
                anim.SetFloat("Direction", 1);
            }

            if ((Input.GetKeyUp(KeyCode.A) && IsRT == false) || (Input.GetKeyUp(KeyCode.D) && IsLT == false))
            {
                anim.SetFloat("Direction", 0);
            }


        }

        if (Input.GetKey(KeyCode.A) && IsRT == false && IsFW == false && IsBK == false) // 左走;
        {
            anim.SetFloat("Speed", 0);
            
            IsLT = true;
            
        }
        
        if (Input.GetKey(KeyCode.D) && IsLT == false && IsFW == false && IsBK == false) // 右走
        {
            anim.SetFloat("Speed", 0);
            
            IsRT = true;
            
        }


        if(Input.GetKeyUp(KeyCode.W)) { IsFW = false; }
        if (Input.GetKeyUp(KeyCode.S)) { IsBK = false; }
        if(Input.GetKeyUp(KeyCode.A)) { IsLT = false; }
        if (Input.GetKeyUp(KeyCode.D)) {  IsRT = false; }
        if (Input.GetKeyUp(KeyCode.Q)) { IsQ = false; }
        if (Input.GetKeyUp(KeyCode.E)) { IsE = false; }



    }
}
