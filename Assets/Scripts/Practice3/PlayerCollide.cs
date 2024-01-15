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
            PlayerAction.Instance.HpImage.fillAmount = PlayerAction.Instance.Hp / PlayerAction.Instance.MaxHp;

            if (PlayerAction.Instance.Hp == 0)
            {
                Destroy(PlayerAction.Instance.gameObject);
                
            }
        }
    }
}
