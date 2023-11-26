using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimation : MonoBehaviour
{
    Animation Anim;

    bool IsFW, IsBK, IsLT, IsRT;

    private void Start()
    {

        Anim = GetComponent<Animation>();
        Anim.Play();

        IsFW = false;
        IsBK = false;
        IsLT = false;
        IsRT = false;


    }

    void Update()
    {


        if (Input.GetKey(KeyCode.W) && IsBK == false )
        {
            IsFW = true;
            Anim.Play();
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
