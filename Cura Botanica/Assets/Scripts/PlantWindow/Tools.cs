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

    [SerializeField] private double sprayHumidity = 0.05;

    //[SerializeField] private bool LightOff = true;
    [SerializeField] private Image lightImage;
    public Sprite lightOffSprite;
    public Sprite lightOnSprite;


    public void Awake()
    {
        _waterAmountSlider.onValueChanged.AddListener((v) =>
        {
            _waterAmountText.text = v.ToString("0" + " мл");
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

    public void LightShift()
    {
        if (activePlant.lightOn)
        {
            lightImage.sprite = lightOffSprite;
            activePlant.ChangeLightAmount(-3000);
            activePlant.lightOn = false;
        }
        else
        {
            lightImage.sprite = lightOnSprite;
            activePlant.ChangeLightAmount(3000);
            activePlant.lightOn = true;
        }
    }

    public void MakeRightLight()
    {
        Debug.Log("я мен€ю свет!");
        if (activePlant.lightOn)
        {
            lightImage.sprite = lightOnSprite;
        }
        else
        {
            lightImage.sprite = lightOffSprite;
        }
    }
}


