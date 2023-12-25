using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDominoe : MonoBehaviour
{

    public GameObject DominoePrefab , DominoeEnd;

    [SerializeField]int Num;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

        pos = DominoeEnd.transform.position - transform.position;
        float interval = (pos.magnitude / (Num + 1)); // Num�O�������P�ƶq +1�O���F�ⶡ�ؼƶq �Z�����󶡻ؼƶq����C�Ӷ��ضZ�� magnitude�Ω����I�������Z��

        //Debug.Log("first" + pos);
        pos.Normalize(); // �u�n��V �]���k�@��
        //Debug.Log("last" + pos);

        for (int i = 1;i <= Num;i++)
        {
            Instantiate(DominoePrefab , transform.position + interval * i * pos , Quaternion.Euler(0,90,0));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
