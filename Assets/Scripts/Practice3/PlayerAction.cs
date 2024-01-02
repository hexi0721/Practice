using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject playerBullet;


    [SerializeField]
    float speed; // 玩家速度
    


    void Start()
    {
        
    }

    
    void Update()
    {

        Move(); // 移動

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBullet, new Vector3(transform.position.x , transform.position.y, transform.position.z + 0.55f) , Quaternion.identity);


        }
        


    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(speed * Vector3.left * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Vector3.right * Time.deltaTime, Space.Self);
        }
    }
}
