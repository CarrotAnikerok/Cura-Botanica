using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* Responsible for setting and saving and loading display preferences.
*/
public class DisplaySettingsManager : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private float currentRefreshRate;
    private List<Resolution> filteredResolutions;
    private int currentResolutionIndex;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        filteredResolutions = filterResolutions(resolutions);

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string option = filteredResolutions[i].width + " x " + filteredResolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);

        LoadResolution();
    }

    private List<Resolution> filterResolutions(Resolution[] resolutions)
    {
        currentRefreshRate = Screen.currentResolution.refreshRate;
        filteredResolutions = new List<Resolution>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        return filteredResolutions;
    }
    
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.SetResolution(Screen.width, Screen.height, isFullScreen); // Doesn't work yet
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution currentResolution = filteredResolutions[resolutionIndex]; 
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

        resolutionDropdown.value = Convert.ToInt32(currentSettings[0]);
        bool isFullScreen = Convert.ToBoolean(currentSettings[1]);
        SetResolution(Convert.ToInt32(currentSettings[0]));
        resolutionDropdown.RefreshShownValue();
    }
}
