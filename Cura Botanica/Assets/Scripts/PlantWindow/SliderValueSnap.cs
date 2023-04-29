using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueSnap : MonoBehaviour
{
    public float snapInterval = 10; //any interval you want to round to
    private Slider sliderUI;

    void Start()
    {
        sliderUI = gameObject.GetComponent<Slider>();
        sliderUI.onValueChanged.AddListener(delegate { ShowSliderValue(); });
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        float value = sliderUI.value;
        value = Mathf.Round(value / snapInterval) * snapInterval;
        sliderUI.value = value;
    }
}
