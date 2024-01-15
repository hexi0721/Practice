using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpLookAtCam : MonoBehaviour
{

    public Camera cam;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform.position);
    }
}
