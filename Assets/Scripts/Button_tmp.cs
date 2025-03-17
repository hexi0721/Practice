using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_tmp : MonoBehaviour
{
    public MyCharacter character;
    bool Switch = true;


    private void OnCollisionEnter(Collision collision)
    {

        if(Switch)
        {
            character.CharacterMove();

            Switch = false;
        }


        
    }


}

