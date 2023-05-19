using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tools : MonoBehaviour
{
    public Plant activePlant;

    [SerializeField] private Slider _waterAmountSlider;
    [SerializeField] private TextMeshProUGUI _waterAmountText;
    private double _sliderValue;

    private double sprayHumidity = 0.05;

    public void Awake()
    {
        _waterAmountSlider.onValueChanged.AddListener((v) =>
        {
            _waterAmountText.text = v.ToString("0" + " ��");
        });
    }

     public void WaterActivePlant()
    {
        _sliderValue = _waterAmountSlider.value;
        Debug.Log("In water method " + _sliderValue);
        activePlant.Pour(_sliderValue);
        Debug.Log(activePlant.name + " " + activePlant.waterCoefficient);
    }

    public void SprayActivePlant()
    {
        activePlant.Spray(sprayHumidity);
        FindObjectOfType<AudioManager>().Play("SpraySound");
    }
}


