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
        float interval = (pos.magnitude / (Num + 1)); // Num是中間骨牌數量 +1是為了算間隙數量 距離除於間隙數量等於每個間隙距離 magnitude用於算兩點之間的距離

        //Debug.Log("first" + pos);
        pos.Normalize(); // 只要方向 因此歸一化
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
