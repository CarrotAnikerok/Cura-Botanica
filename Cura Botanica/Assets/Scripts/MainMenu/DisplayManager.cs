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
        // Screen.fullScreen = isFullScreen; // previous solution
        // Debug.Log("Toggle is on:" + isFullScreen + "\n" + "Full screen mode is on:" + Screen.fullScreen); // uncomment for debug
        Screen.SetResolution(Screen.width, Screen.height, isFullScreen);
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

        Debug.Log("Screen settings" + ": " + currentSettings[0] + ", " + currentSettings[1]);

        resolutionDropdown.value = Convert.ToInt32(currentSettings[0]);
        bool isFullScreen = Convert.ToBoolean(currentSettings[1]);
        SetResolution(Convert.ToInt32(currentSettings[0]));
    }
}
