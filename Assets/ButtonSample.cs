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

    private Animator animator;


    Transform dragging;
    Vector3 offset;


    [SerializeField] private string s;
    [SerializeField] private List<GameObject> obj;



    // Start is called before the first frame update
    void Start()
    {
        
        btntest = new Rect();

        Humen = new List<GameObject>();
        pos = new Vector3(0,3,0);

        s = "Hello World";

        animator = GetComponent<Animator>();

        dragging = null;
        offset = Vector3.zero;
    }

    private void Update()
    {
        /*if(Input.GetMouseButtonDown(0)) 
        {
            n = Random.Range(1, 4);
            Human.transform.localScale = new Vector3(n , n , n);

            GameObject G =  Instantiate(Human, pos, Quaternion.identity) as GameObject;
            Humen.Add(G);

            pos = new Vector3(0,pos.y+3,0);   


            n = Random.Range(0, 4);
            Instantiate(obj[n], pos + new Vector3(1,0,0), Quaternion.identity) ;

        
        }

        if(Input.GetMouseButtonDown(1)) 
        {
            animator.enabled = !animator.enabled;
        }*/

        
        if (Input.GetMouseButtonDown(0)) 
        {

            /*
            Debug.Log("Input.mousePosition: " + Input.mousePosition);
            Debug.Log("Camera.main.ScreenToWorldPoint(Input.mousePosition) : " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log("Camera.main.WorldToScreenPoint(Input.mousePosition) : " + Camera.main.WorldToScreenPoint(Input.mousePosition));
            */

            if(dragging == null)
            {
                RaycastHit hit = raycast();

                if(hit.collider != null) 
                {
                    if(hit.transform.CompareTag("Human"))
                        dragging = hit.transform;

                    Vector3 MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(dragging.position).z);
                    offset = dragging.position - Camera.main.ScreenToWorldPoint(MousePos);
                    
                }


            }
            

        }

        if(Input.GetMouseButtonUp(0))
        {
            dragging = null;
        }


        if (dragging != null)
        {
            Vector3 MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(dragging.position).z);
            Vector3 WorldPos = Camera.main.ScreenToWorldPoint(MousePos) + offset;

            WorldPos.y = dragging.position.y;

            
            dragging.position = WorldPos ;

        }

    }

    private RaycastHit raycast()
    {
        RaycastHit hit ;

        Vector3 ScreenPosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 ScreenPosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);

        /*
        Debug.Log(Camera.main.nearClipPlane);
        Debug.Log(Camera.main.farClipPlane);
        */

        Vector3 WorldPosNear = Camera.main.ScreenToWorldPoint(ScreenPosNear);
        Vector3 WorldPosFar = Camera.main.ScreenToWorldPoint(ScreenPosFar);
        /*
        Debug.Log(WorldPosNear);
        Debug.Log(WorldPosFar);
        */

        Physics.Raycast(WorldPosNear, WorldPosFar - WorldPosNear, out hit);


        return hit;
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

        s = GUI.TextField(new Rect(20, 80, 100, 20) , s , skin.textField );
            

    }
}
