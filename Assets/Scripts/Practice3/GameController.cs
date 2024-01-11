using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameController : MonoBehaviour
{
    float Level;
    float ItemPrefabCoolDown; // 生成道具的冷卻時間
    GameObject GameOver;// 遊戲結束文字
    
    public GameObject ItemPrefab; // 道具

    void Start()
    {
        Level = 0;

        GameOver = GameObject.Find("GameOver");
        GameOver.SetActive(false);



        ItemPrefabCoolDown = 15; // 冷卻15秒

    }

    void Update()
    {
        
        if(PlayerAction.Instance.Hp == 0)
        {
            GameOver.SetActive(true);
        }


        InstantiateItem();    


    }

    private void InstantiateItem() // 生成道具方法
    {
        if (ItemPrefabCoolDown >= 0)
        {
            ItemPrefabCoolDown -= Time.deltaTime;
        }
        else
        {
            
            Instantiate(ItemPrefab , new Vector3(Random.Range(-2.6f, 2.6f) , 0 , Random.Range(-4.8f  , - 2.4f)) , Quaternion.identity);
            ItemPrefabCoolDown = 15;
        }
    }
}
