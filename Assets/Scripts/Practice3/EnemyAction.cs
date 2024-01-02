using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    
    bool DontMove = false;
    float Range , maxRange , minRange;

    [SerializeField]
    int enemySpeed;

    private void Start()
    {
        SetRange();
    }

    void Update()
    {
        
        if (transform.position.x > minRange && transform.position.x < maxRange)
        {
            Invoke("SetRange" , 1.0f);
            DontMove = true;
            
        }
        
        if(transform.position.x < Range && DontMove)
        {
            transform.Translate(enemySpeed * Vector3.right * Time.deltaTime);

        }
        else
        {
            transform.Translate(enemySpeed * Vector3.left * Time.deltaTime);
        }


    }

    private void SetRange()
    {
        Range = Random.Range(-3.7f, 3.7f); 
        maxRange = Range + 0.2f;
        minRange = Range - 0.2f;
    }
}
