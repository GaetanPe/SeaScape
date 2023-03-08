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

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
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
        if (Screen.fullScreen != true)
        {
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
        else
        {
            Screen.SetResolution(Screen.width, Screen.height, true);
        }
    }

    public void ClosedSetting()
    {
        settings.SetActive(false);
    }
}
