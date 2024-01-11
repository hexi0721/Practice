using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameController : MonoBehaviour
{
    float Level;
    float ItemPrefabCoolDown; // �ͦ��D�㪺�N�o�ɶ�
    GameObject GameOver;// �C��������r
    
    public GameObject ItemPrefab; // �D��

    void Start()
    {
        Level = 0;

        GameOver = GameObject.Find("GameOver");
        GameOver.SetActive(false);



        ItemPrefabCoolDown = 15; // �N�o15��

    }

    void Update()
    {
        
        if(PlayerAction.Instance.Hp == 0)
        {
            GameOver.SetActive(true);
        }


        InstantiateItem();    


    }

    private void InstantiateItem() // �ͦ��D���k
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
