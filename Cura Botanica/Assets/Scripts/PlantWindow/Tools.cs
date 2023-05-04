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

    [SerializeField] private double sprayHumidity;

    public void Awake()
    {
        sprayHumidity = 0.05;
        _waterAmountSlider.onValueChanged.AddListener((v) =>
        {
            _waterAmountText.text = v.ToString("0" + " мл");
        });
    }

    /// <summary>
    /// Обеспечивает полив в меню растения
    /// </summary>
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

    }
}


