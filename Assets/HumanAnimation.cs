using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimation : MonoBehaviour
{
    public float animspeed = 1.5f;
    Animator anim;


    bool IsFW, IsBK, IsLT, IsRT;

    private void Start()
    {

        anim = GetComponent<Animator>();
        animspeed = anim.GetCurrentAnimatorStateInfo(0).speed;

        IsFW = false;
        IsBK = false;
        IsLT = false;
        IsRT = false;


    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);

        if (Input.GetKey(KeyCode.W) && IsBK == false )
        {
            IsFW = true;
            
            transform.Translate(Vector3.forward * Time.deltaTime * 5 , Space.Self);

            if (Input.GetKey(KeyCode.A) && IsRT == false)
            {
                IsLT = true;
                transform.RotateAround(transform.position , new Vector3(0,1,0) , -60 * Time.deltaTime );
                
            }

            if (Input.GetKey(KeyCode.D) && IsLT == false)
            {
                IsRT = true;
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), 60 * Time.deltaTime);
                
            }

        }
        
        if (Input.GetKey(KeyCode.S) && IsFW == false)
        {
            IsBK = true;

            transform.Translate(Vector3.back * Time.deltaTime * 2, Space.Self);

            if (Input.GetKey(KeyCode.A) && IsRT == false)
            {
                IsLT = true;
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), 60 * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.D) && IsLT == false)
            {
                IsRT = true;
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), -60 * Time.deltaTime);

            }

        }

        if (Input.GetKey(KeyCode.A) && IsRT == false && IsFW == false && IsBK == false)
        {
            // Debug.Log("往左走");
            IsLT = true;
            transform.Translate(Vector3.left * Time.deltaTime * 4, Space.Self);
        }
        
        if (Input.GetKey(KeyCode.D) && IsLT == false && IsFW == false && IsBK == false)
        {
            // Debug.Log("往右走");
            IsRT = true;
            transform.Translate(Vector3.right * Time.deltaTime * 4, Space.Self);
        }


        if(Input.GetKeyUp(KeyCode.W)) { IsFW = false; }
        if (Input.GetKeyUp(KeyCode.S)) { IsBK = false; }
        if(Input.GetKeyUp(KeyCode.A)) { IsLT = false; }
        if (Input.GetKeyUp(KeyCode.D)) {  IsRT = false; }



    }
}
