using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    GameObject GameOver; // �C��������r

    public PlayerAction player;

    void Start()
    {

        GameOver = GameObject.Find("GameOver");
        GameOver.SetActive(false);

        

    }

    void Update()
    {
        if(player.Hp == 0)
        {
            GameOver.SetActive(true);
        }
    }


}
