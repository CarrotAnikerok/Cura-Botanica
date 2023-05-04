using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoSystem : MonoBehaviour
{
    Plant plant;
    [SerializeField] TextMeshProUGUI[] childrenText;
    void OnEnable()
    {
        plant = GameObject.Find("ActivePlantButton").GetComponent<GamePlant>().plant;
        childrenText = GetComponentsInChildren<TextMeshProUGUI>();

        childrenText[1].text = ((int)(plant.waterCoefficient * 100)).ToString() + "%";
        Debug.Log((int)(plant.waterCoefficient * 100));
    }

    void Update()
    {
        //childrenText[1].text = ((int) (plant.waterCoefficient * 10)).ToString("0" + "%");
    }
}
