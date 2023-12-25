using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public MyCharacter character;

    GameObject FinishText;

    private void Start()
    {
        FinishText = GameObject.Find("FinishText");
        FinishText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.CompareTag("Human"))
        {
            
            character.CharacterStop();
            FinishText.SetActive(true);
        }

        
    }

    
}
