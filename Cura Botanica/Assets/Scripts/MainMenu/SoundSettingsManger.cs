using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* Responsible for setting and saving and loading sound preferences.
*/
public class SoundSettingsManger : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    [SerializeField] private TextMeshProUGUI volumeTextUI;

    private void Start()
    {
        LoadValues();
    }

    public void UpdateVolumeSlider(float volume)
    {
        int roundedVolume = Convert.ToInt32(volume);
        string volumeValueText = roundedVolume.ToString();
        volumeTextUI.SetText(volumeValueText);
    }

    public void SaveVolumeValue()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue * 0.01f;
    }
    
}
