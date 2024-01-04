using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAction : MonoBehaviour
{
    public GameObject playerBullet;
    PlayerAction p;

    float Range; // ����ಾ�ʪ��ϰ�


    [SerializeField]
    float speed; // ���a�t��
    public int Hp; // ���a�ͩR


    void Start()
    {

        Range = -4.75f;
        Hp = 3;

        p = GetComponent<PlayerAction>();
    }

    
    void Update()
    {

        Move(); 
        Shoot();

        

        


    }

    private void Shoot() // �g��
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.55f), Quaternion.identity);
        }
    }

    private void Move() // ����
    {
        if (Input.GetKey(KeyCode.W) && transform.position.z <= Range/2)
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.S) && transform.position.z >= Range)
        {
            transform.Translate(speed * Vector3.back * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x >= Range)
        {
            transform.Translate(speed * Vector3.left * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x <= -Range)
        {
            transform.Translate(speed * Vector3.right * Time.deltaTime, Space.Self);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("EnemyBullet"))
        {
            Hp--;
            if (Hp == 0)
            {
                Destroy(gameObject);
                p.enabled = false;
            }
        }
    }
}
