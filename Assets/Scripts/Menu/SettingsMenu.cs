using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    Resolution [] resolutions;

    [SerializeField] private GameObject settings;

       
    void Start()
    {
        settings.SetActive(false);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentRexolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++) 
        {
            string option = resolutions[i].width +" X "+ resolutions[i].height.ToString();
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) 
            {
                currentRexolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentRexolutionIndex;
        resolutionDropdown.RefreshShownValue();
        Screen.fullScreen= true;
    }
    public void SetFullScreen (bool isFullScreen)
    {
        
        Screen.fullScreen = isFullScreen;
    }

    public void ResolutionIndex(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void ClosedSetting()
    {
        settings.SetActive(false);
    }
}
