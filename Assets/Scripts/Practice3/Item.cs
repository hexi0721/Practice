using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    

    float surviveTime; // ­Æ¦s®É¶¡

    private void Start()
    {
        surviveTime = 10;
        
    }

    private void Update()
    {

        surviveTime -= Time.deltaTime;

        if (surviveTime < 0) 
        {
            Destroy(gameObject);
        
        }



        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerAction.Instance.TripleShotItemActivate = true;
            Destroy(gameObject);
            
        }
    }



}
