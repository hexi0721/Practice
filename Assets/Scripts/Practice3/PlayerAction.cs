using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAction : MonoBehaviour
{

    static PlayerAction _instance;

    public static PlayerAction Instance { 

        get { return _instance; }
    }




    public GameObject playerBullet;
    PlayerAction p; // ����

    float Range; // ����ಾ�ʪ��ϰ�
    float time;

    [Header("���a�ݩ�")]
    [SerializeField] float speed; // ���a�t��
    [SerializeField] public int Hp; // ���a�ͩR ��GameController�P�_0�ɵ����C��
    [SerializeField] float AttackSpeed;
    int shootMode; // 0:��o , 1:�T�o
    public bool TripleShotItemActivate;
    float TripleShotItemActivateEndTime;

    private void Awake()
    {
        _instance = this;
    }


    void Start()
    {

        Hp = 3;
        speed = 1.0f;
        AttackSpeed = 1.0f;

        shootMode = 0;
        Range = -2.47f;
        TripleShotItemActivate = false;

        p = GetComponent<PlayerAction>();
    }

    
    void Update()
    {
        time += Time.deltaTime;
        Move(); 
        Shoot();
        TripleShotItem();



    }

    private void TripleShotItem() // �T�o�D��Ĳ�o
    {   
        if (TripleShotItemActivate)  
        {
            shootMode = 1;
            TripleShotItemActivateEndTime = 5.0f;
            TripleShotItemActivate = false;
        }

        if(TripleShotItemActivateEndTime > 0)
        {
            TripleShotItemActivateEndTime -= Time.deltaTime;
        }
        else
        {
            shootMode = 0;
        }
        
    }

    private void Shoot() // �g��
    {



        if (time > (1/AttackSpeed))
        {
            switch (shootMode)
            {
                case 0:


                    Instantiate(playerBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.55f), Quaternion.identity);

                    break;

                case 1:

                    Instantiate(playerBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.55f), Quaternion.identity);
                    Instantiate(playerBullet, new Vector3(transform.position.x + 0.15f, transform.position.y, transform.position.z + 0.55f), Quaternion.Euler(0, 5, 0));
                    Instantiate(playerBullet, new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z + 0.55f), Quaternion.Euler(0, -5, 0));

                    break;
            }

            time = 0f;
        }

        

        
    }

    private void Move() // ����
    {


        if (Input.GetKey(KeyCode.W) && transform.position.z <= -4.73f/2.0f)
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.S) && transform.position.z >= -4.73f)
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


    /*private void OnCollisionEnter(Collision collision)
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
    }*/


    
}
