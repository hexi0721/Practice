using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{

    public Toggle toggle;
    

    private void Awake()
    {
        toggle.isOn = Screen.fullScreen;

        if (toggle.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }

    }

    public void SetFullScreen()
    {
        
        Screen.fullScreen = !Screen.fullScreen;
        
    }


}
