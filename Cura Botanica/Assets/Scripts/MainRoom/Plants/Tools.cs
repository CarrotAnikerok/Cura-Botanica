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

    /// <summary>
    /// Обеспечивает полив в меню растения
    /// </summary>
    /// 
    public void WaterActivePlant()
    {
        _sliderValue = _waterAmountSlider.value;
        _waterAmountSlider.onValueChanged.AddListener((v) =>
        {
            _waterAmountText.text = v.ToString("0");
        });

        activePlant.Pour(_sliderValue);
        Debug.Log(activePlant.name + " " + activePlant.waterCoefficient);
    }

}
