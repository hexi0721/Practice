using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("EnemyBullet"))
        {


            PlayerAction.Instance.Hp--;
            if (PlayerAction.Instance.Hp == 0)
            {
                Destroy(PlayerAction.Instance.gameObject);
                //p.enabled = false;
            }
        }
    }
}
