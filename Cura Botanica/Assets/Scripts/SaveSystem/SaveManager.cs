using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to call SaveSystem methods in Unity editor 
public class SaveManager : MonoBehaviour
{
    public SpecialPlant specialPlant;
    public PlantButton[] plantButtons;
    public PlantSlot[] plantSlots;

    void Start()
    {
        LoadData();
    }

    public void SaveData() // Triggers via buttons on scene
    {
        SaveSystem.SaveSpecialPlant(specialPlant);
        SaveSystem.SavePlants(plantButtons);
    }

    public void LoadData()
    {
        SaveSystem.LoadSpecialPlant(specialPlant);
        SaveSystem.ArrangePlants(plantButtons, plantSlots);
    }
}
