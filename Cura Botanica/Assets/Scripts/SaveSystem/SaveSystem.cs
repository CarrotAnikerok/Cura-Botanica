using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    static string plantsSavingPath = Application.persistentDataPath + "/plants.save";
    static string specialPlantSavingPath = Application.persistentDataPath + "/specialPlant.save";

    // public static void LoadData(SpecialPlant specialPlant) 
    // {
    //     // ArrangePlants(); // Doesn't work yet 
    //     LoadSpecialPlant(specialPlant); // Nothing to load yet. Special plant system is still in progress
    // }

    public static void SavePlants(PlantButton[] existingPlants)
    {
        Debug.LogWarning("Saving plants...");
        int plantsNumber = existingPlants.Length;
        
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(plantsSavingPath, FileMode.Create))
        {
            PlantData[] existingPlantsData = new PlantData[plantsNumber];
            for (int i = 0; i < plantsNumber; i++) 
            {
                existingPlantsData[i] = new PlantData(existingPlants[i]);

                Debug.LogWarning("Plant " + existingPlants[i].plant.plantName + " is saved.");
            }

            formatter.Serialize(stream, existingPlantsData);
            Debug.LogWarning("Plants are saved: " + existingPlantsData.Length);
        }
    }

    public static void ArrangePlants(PlantButton[] plantButtonsOnScene, PlantSlot[] plantSlots)
        {
            PlantButton[] savedPlants = SaveSystem.LoadPlants(plantButtonsOnScene);

            int[] usedSlots = new int[savedPlants.Length];
            for (int i = 0; i < savedPlants.Length; i++)
            {
                usedSlots[i] = savedPlants[i].placeIndex;
            }

            foreach (int slot in usedSlots)
            {
                foreach (PlantButton plant in savedPlants)
                {
                    plant.transform.SetParent(plantSlots[slot].transform);
                }
            }
        }

    private static PlantButton[] LoadPlants(PlantButton[] plantButtonsOnScene)
    {
        Debug.LogWarning("Loading plants...");

        if (File.Exists(plantsSavingPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(plantsSavingPath, FileMode.Open)) 
            {
                PlantData[] savedPlantsData = formatter.Deserialize(stream) as PlantData[]; // Binary data read from save file

                int plantsNumber = savedPlantsData.Length;
                PlantButton[] savedPlants = new PlantButton[plantsNumber]; // Array to return. Full of nulls at this point

                foreach (PlantData plantData in savedPlantsData)
                {
                    for (int i = 0; i < plantsNumber; i++)
                    {
                        GameObject buttonObject = CreateButtonObject(plantData.name); // Creating a new object in the scene

                        PlantButton plantButton = buttonObject.GetComponent<PlantButton>(); // Pulling PlantButton component to set plant settings
                        
                        // Debug.LogError("Plant button: " + plantButton + ". Plant data: " + plantData); // Debug moment

                        plantButton.plant.plantName = plantData.name; // assigning saved variables to variables of plant of just created plantButton
                        plantButton.plant.state = plantData.state;
                        plantButton.plant.waterCoefficient = plantData.waterCoefficient;

                        savedPlants[i] = plantButton; // reassigning null to actual PlantButton object
                    }
                }

                // for (int i = 0; i < plantsNumber; i++) // nvm
                // {
                //     savedPlants[i].plant.plantName = savedPlantsData[i].name;
                //     savedPlants[i].plant.state = savedPlantsData[i].state;
                //     savedPlants[i].plant.waterCoefficient = savedPlantsData[i].waterCoefficient;
                // }
                
                Debug.LogWarning("Plants are loaded!");
                return savedPlants;
            }
        } else
        {
            Debug.LogError("Save file not found in " + plantsSavingPath);
            return null;
        }
    }

    static GameObject CreateButtonObject(string plantName)
    {
        GameObject buttonObject = new GameObject("ButtonObject");
        buttonObject.AddComponent<PlantButton>();
        buttonObject.AddComponent<DraggableItem>();
        // buttonObject.AddComponent<>(); // Don't understand how to add script of particular plant with its string name like "AloeVera"

        return buttonObject;
    }

    public static void SaveSpecialPlant(SpecialPlant specialPlant)
    {
        Debug.LogWarning("Saving special plant...");

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(specialPlantSavingPath, FileMode.Create))
        {
            SpecialPlantData specialPlantData = new SpecialPlantData(specialPlant);

            formatter.Serialize(stream, specialPlantData);
        }

        Debug.LogWarning("Special plant is saved!");
    }

    public static void LoadSpecialPlant(SpecialPlant specialPlantOnScene)
    {

        Debug.LogWarning("Loading special plant...");

        if (File.Exists(specialPlantSavingPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(specialPlantSavingPath, FileMode.Open))
            {
                SpecialPlantData specialPlantData = formatter.Deserialize(stream) as SpecialPlantData;

                //Color specialPlantColor = CreateColor(specialPlantData);
                
                specialPlantOnScene.elementIndex = specialPlantData.elementIndex;
                specialPlantOnScene.isTuned = specialPlantData.isTuned;
                //specialPlantOnScene.flowerColor = specialPlantColor;

                specialPlantOnScene.Tune();
            }
            Debug.LogWarning("Special plant is loaded!");
        } else
        {
            Debug.LogError("Save file not found in " + specialPlantSavingPath);
        }
    }

    private static Color CreateColor(SpecialPlantData specialPlantData)
    {
        float A = specialPlantData.color[0];
        float R = specialPlantData.color[1];
        float G = specialPlantData.color[2];
        float B = specialPlantData.color[3];
        return new Color (A, R, G, B);
    }
}
