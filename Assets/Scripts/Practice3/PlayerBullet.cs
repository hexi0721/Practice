using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;

    void Update()
    {
        transform.Translate(bulletSpeed * Vector3.forward * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision != null)
        {
            Debug.Log(collision.transform.name);
        }

        Destroy(gameObject);
    }
}
