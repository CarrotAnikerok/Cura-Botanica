using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayManager : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;

    // [SerializeField] private Toggle FullScreenToggle;

    Resolution[] resolutions;

    private void Start()
    {

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);

        LoadResolution();
    }
    
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution currentResolution = resolutions[resolutionIndex]; 
        Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
    }

    public void SaveResolution()
    {
        string resolutionSettings = resolutionDropdown.value + ", " + Screen.fullScreen;
        PlayerPrefs.SetString("ScreenSettings", resolutionSettings);
        LoadResolution();
    }

    public void LoadResolution()
    {
        string resolutionSettings = PlayerPrefs.GetString("ScreenSettings");
        string[] currentSettings = resolutionSettings.Split(", ");
        resolutionDropdown.value = int.Parse(currentSettings[0]);
        bool isFullScreen = Convert.ToBoolean(currentSettings[1]);
        SetResolution(int.Parse(currentSettings[0]));
    }
}
