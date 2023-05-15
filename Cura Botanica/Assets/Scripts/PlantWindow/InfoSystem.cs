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

        UpdateInfo(1, plant.waterCoefficient);
        UpdateInfo(2, plant.lightAmount, " À ");
        UpdateInfo(3, plant.humidity);
        Debug.Log(plant.humidity + " what is going on woth you");
        UpdateInfo(4, plant.temperature, "∞");
    }

    void UpdateInfo(int index, double category)
    {
         childrenText[index].text = ((int) (category * 100)).ToString() + "%";
         Debug.Log(index + " " + (int)(category * 100));
    }
    void UpdateInfo(int index, int category, string symbol)
    {
        childrenText[index].text = ((int) category).ToString() + symbol;
        Debug.Log(index + " " + (int) category);
    }


}
