using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// May be used to call SaveSystem methods in Unity editor 
public class SaveManager : MonoBehaviour
{
    public SpecialPlant specialPlant;
    public PlantButton[] plantButtons;

    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        Debug.LogWarning("Saving...");

        SaveSystem.SaveSpecialPlant(specialPlant);
        SaveSystem.SavePlants(plantButtons);
    }

    public void LoadData()
    {
        SaveSystem.LoadSpecialPlant(specialPlant);
        // SaveSystem.ArrangePlants(plantButtons, GameObject.FindObjectsOfType<PlantSlot>());
    }
}
