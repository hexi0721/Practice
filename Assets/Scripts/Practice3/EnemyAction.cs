using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public GameObject EnemyBulletPrefab;
    //public int tmp;

    bool DontMove;
    float Range , maxRange , minRange;
    int AttackRestTIme; 

    [SerializeField]
    int enemySpeed; // �ĤH�t��
    int Hp; // �ĤH�ͩR

    private void Start()
    {
        Hp = 25;

        DontMove = false;
        
        AttackRestTIme = 2;
        SetRange();

        
    }

    void Update()
    {

        Move();

        if(AttackRestTIme == 0)
        {
            Shoot();
        }
        else
        {
            AttackRestTIme -= 1;
        }

        





    }

    private void Shoot() // �g��
    {
        Instantiate(EnemyBulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.3f), Quaternion.identity);
        AttackRestTIme = 40;
    }

    private void Move() // ����
    {
        if (transform.position.x > minRange && transform.position.x < maxRange && !DontMove)
        {
            DontMove = true;
            Invoke("Rest", 1.5f);
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
        Range = Random.Range(-3.7f, 3.7f); 
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
            if(Hp == 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
