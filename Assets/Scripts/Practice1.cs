using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice1 : MonoBehaviour
{
    public GameObject Dominoe ;

    GameObject empty , G;
    float radius = 2.0f;
    [SerializeField] int Num;


    Vector3 pos;

    
    void Start()
    {
        empty = GameObject.Find("Practice1");
        
        

        for (int i = 1; i <= Num; i++)
        {
            float angle = Mathf.PI * 2 * i / Num;
            pos = new Vector3(Mathf.Cos(angle), 0 , Mathf.Sin(angle)) * radius;

            G = Instantiate(Dominoe, transform.position + pos, Quaternion.EulerAngles(angle)) as GameObject;
            G.transform.SetParent(empty.transform);
        }

    }

    
}
