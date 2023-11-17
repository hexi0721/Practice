using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSample : MonoBehaviour
{

    int n;
    Rect btntest;

    public GameObject Human;
    private List<GameObject> Humen;
    Vector3 pos ;
    
    public GUISkin skin;
    // Start is called before the first frame update
    void Start()
    {
        n = 0;
        btntest = new Rect();

        Humen = new List<GameObject>();
        pos = new Vector3(0,3,0);
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            

            GameObject G =  Instantiate(Human, pos, Quaternion.identity) as GameObject;
            Humen.Add(G);

            pos = new Vector3(0,pos.y+3,0);   
        }

    }


    private void OnGUI()
    {
        btntest.x = Screen.width / 2;
        btntest.y = Screen.height / 2;
        btntest.width = Screen.width /3;
        btntest.height = Screen.height /3;
        


        if (GUI.Button(btntest, "buttontest" , skin.button))
        {
            
            foreach(GameObject go in Humen) 
            {
                Debug.Log(go.transform.name);
                Destroy(go);
            }

            Humen.Clear();

        }

        GUI.Label(new Rect(20, 20, 60, 60), "Hello" , skin.label);




    }
}
