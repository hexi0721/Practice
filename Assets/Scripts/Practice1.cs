using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Practice1 : MonoBehaviour
{
    public GameObject Dominoe ;
    
    public float Force;

    GameObject G;
    List<GameObject> DominoeList = new List<GameObject>();
    float radius = 5f;
    [SerializeField] int Num;


    Vector3 pos;

    
    void Start()
    {

        for (int i = 1; i <= Num; i++)
        {
            float angle = Mathf.PI * 2 * i / Num;
            pos = new Vector3(Mathf.Cos(angle), 0 , Mathf.Sin(angle)) * radius;
            

            G = Instantiate(Dominoe, transform.position + pos, Quaternion.identity) as GameObject;
            DominoeList.Add(G);

        }

        
        for (int i = 0;i < Num-1;i++) 
        {

            DominoeList[i].transform.LookAt(DominoeList[i + 1].transform.position);

        }
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            DominoeList[0].GetComponent<Rigidbody>().AddRelativeForce(0, 0, Force, ForceMode.Impulse);

        }

        
    }


}
