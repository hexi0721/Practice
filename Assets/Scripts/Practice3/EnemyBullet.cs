using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;

    
    void Update()
    {
        transform.Translate(bulletSpeed * new Vector3(0,0,-1) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.transform.CompareTag("EnemyBullet"))
        {
            //Debug.Log(collision.transform.name);
            Destroy(gameObject);
        }

        
    }
}
