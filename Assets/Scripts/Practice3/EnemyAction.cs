using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class EnemyAction : MonoBehaviour
{
    public GameObject EnemyBulletPrefab;
    public Slider SliderHP;
    //public int tmp;

    bool DontMove;
    float Range , maxRange , minRange;
    float time;


    [Header("Boss�ݩ�")]

    [SerializeField] float enemySpeed; // �ĤH�t��
    [SerializeField] float enemyAttackSpeed; // �ĤH��t
    [SerializeField] int Hp; // �ĤH�ͩR
    [SerializeField] float enemyRestTime;

    private void Start()
    {
        Hp = 25;
        InitHp();
        
        enemyAttackSpeed = 2f;
        enemySpeed = 2.0f;
        enemyRestTime = 1.5f;

        DontMove = false;
        time = 0;
        SetRange();

        
    }

    void Update()
    {
        time += Time.deltaTime;
        
        Move();
        Shoot();

    }


    void InitHp()
    {
        SliderHP.maxValue = Hp;
        SliderHP.value = Hp;
    }

    private void Shoot() // �g��
    {

        if(time > (1 / enemyAttackSpeed))
        {
            Instantiate(EnemyBulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.3f), Quaternion.identity);
            time = 0;
        }
        
        
    }

    private void Move() // ����
    {
        if (transform.position.x > minRange && transform.position.x < maxRange && !DontMove)
        {
            DontMove = true;
            Invoke("Rest", enemyRestTime);
            SetRange();
        }

        if (transform.position.x < Range && !DontMove)
        {
            transform.Translate(enemySpeed * Vector3.right * Time.deltaTime);

        }
        else if (transform.position.x > Range && !DontMove)
        {
            transform.Translate(enemySpeed * Vector3.left * Time.deltaTime);
        }
    } 

    private void SetRange() // �U�Ӧ�m
    {
        Range = Random.Range(-1.73f, 1.73f); 
        maxRange = Range + 0.2f;
        minRange = Range - 0.2f;
    }

    private void Rest() // ���d
    {
        DontMove = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Hp--;
            SliderHP.value = Hp;
            if (Hp == 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
