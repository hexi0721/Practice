using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSetting : MonoBehaviour
{

    Resolution[] resolutionsArr;
    public Dropdown resolutionDropdown;

    
    void Start()
    {
        resolutionsArr = Screen.resolutions;
        resolutionDropdown.ClearOptions();
    }

    
    void Update()
    {
        
    }
}
