using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tools : MonoBehaviour
{
    public Plant activePlant;
    public Handbook handbook;
    public PhaseButton phaseButton;

    [SerializeField] private Slider _waterAmountSlider;
    [SerializeField] private TextMeshProUGUI _waterAmountText;
    private double _sliderValue;

    [SerializeField] private double sprayHumidity = 0.05;
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
        FindObjectOfType<AudioManager>().Play("Watering");
        _sliderValue = _waterAmountSlider.value;
        Debug.Log("In water method " + _sliderValue);
        activePlant.Pour(_sliderValue);
        Debug.Log(activePlant.name + " " + activePlant.waterCoefficient);

        handbook.makeNote(activePlant.plantName + ": полив на " + _sliderValue + " мл", phaseButton.currentPhase);
    }

    public void SprayActivePlant()
    {
        FindObjectOfType<AudioManager>().Play("SpraySound");
        activePlant.Spray(sprayHumidity);
        handbook.makeNote(activePlant.plantName + ": опрыскивание на 5%" , phaseButton.currentPhase);
    }

    public void LightShift()
    {
        FindObjectOfType<AudioManager>().Play("LightSwitch");
        if (activePlant.lightOn)
        {
            lightImage.sprite = lightOffSprite;
            activePlant.humidity += 0.1;
            activePlant.temperature -= 10;
            activePlant.ChangeLightAmount(-3000);
            activePlant.lightOn = false;
            handbook.makeNote(activePlant.plantName + ": свет выключен", phaseButton.currentPhase);
        }
        else
        {
            lightImage.sprite = lightOnSprite;
            activePlant.humidity -= 0.1;
            activePlant.temperature += 10;
            activePlant.ChangeLightAmount(3000);
            activePlant.lightOn = true;
            handbook.makeNote(activePlant.plantName + ": свет включен", phaseButton.currentPhase);
        }
    }

    public void MakeRightLight()
    {
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


