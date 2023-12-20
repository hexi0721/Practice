using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDominoe : MonoBehaviour
{

    public GameObject DominoeStart;

    public float Force;

    void Update()
    {
        
        if(Input.GetMouseButtonDown(0)) 
        {

            DominoeStart.GetComponent<Rigidbody>().AddForce(Force , 0 , 0 , ForceMode.Impulse);

        }


    }
}
