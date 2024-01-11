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
    PlayerAction p; // 本身

    float Range; // 限制能移動的區域
    float time;

    [Header("玩家屬性")]
    [SerializeField] float speed; // 玩家速度
    [SerializeField] public int Hp; // 玩家生命 讓GameController判斷0時結束遊戲
    [SerializeField] float AttackSpeed;
    int shootMode; // 0:單發 , 1:三發
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

    private void TripleShotItem() // 三發道具觸發
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

    private void Shoot() // 射擊
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

    private void Move() // 移動
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
