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

    public static void SavePlants(PlantButton[] existingPlants)
    {
        Debug.Log("Saving plants...");
        int plantsNumber = existingPlants.Length;
        
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(plantsSavingPath, FileMode.Create))
        {
            PlantData[] existingPlantsData = new PlantData[plantsNumber];
            for (int i = 0; i < plantsNumber; i++) 
            {
                existingPlantsData[i] = new PlantData(existingPlants[i]);

                Debug.Log("Plant " + existingPlants[i].plant.plantName + " is saved.");
            }

            formatter.Serialize(stream, existingPlantsData);
        }
    }

    public static void ArrangePlants(PlantButton[] plantButtonsOnScene, PlantSlot[] plantSlots)
        {
            PlantButton[] savedPlants = SaveSystem.LoadPlants(plantButtonsOnScene);
            int savedPlantsNumber = savedPlants.Length;

            int[] usedSlots = new int[savedPlantsNumber];
            for (int i = 0; i < savedPlantsNumber; i++)
            {
                usedSlots[i] = savedPlants[i].placeIndex;
            }

            for (int i = 0; i < savedPlantsNumber; i++)
            {
                Debug.Log("Loading plant: " + savedPlants[i].plant.name + ". Plant place index: " + savedPlants[i].placeIndex + ". Slot number: " + usedSlots[i]);
                savedPlants[i].transform.SetParent(plantSlots[usedSlots[i] - 1].transform);
            }
        }

    private static PlantButton[] LoadPlants(PlantButton[] plantButtonsOnScene)
    {
        Debug.Log("Loading plants...");

        if (File.Exists(plantsSavingPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(plantsSavingPath, FileMode.Open)) 
            {
                PlantData[] savedPlantsData = formatter.Deserialize(stream) as PlantData[];

                string[] possibleStates = {"Perfect", "Good", "Neutral", "Bad", "Horrible", "Dead"};

                for (int i = 0; i < savedPlantsData.Length; i++)
                {
                    int stateIndex = Array.FindIndex(possibleStates, x => x == savedPlantsData[i].state);

                    plantButtonsOnScene[i].plant.plantName = savedPlantsData[i].name;
                    plantButtonsOnScene[i].placeIndex = savedPlantsData[i].placeIndex;
                    plantButtonsOnScene[i].plant.ChangeStateTo(stateIndex);
                    plantButtonsOnScene[i].plant.waterCoefficient = savedPlantsData[i].waterCoefficient;                    
                }
                
                Debug.Log("Plants are loaded!");
                return plantButtonsOnScene;
            }
        } else
        {
            Debug.LogError("Save file not found in " + plantsSavingPath);
            return null;
        }
    }

    public static void SaveSpecialPlant(SpecialPlant specialPlant)
    {
        Debug.Log("Saving special plant...");

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(specialPlantSavingPath, FileMode.Create))
        {
            SpecialPlantData specialPlantData = new SpecialPlantData(specialPlant);

            formatter.Serialize(stream, specialPlantData);
        }

        Debug.Log("Special plant is saved!");
    }

    public static void LoadSpecialPlant(SpecialPlant specialPlantOnScene)
    {

        Debug.Log("Loading special plant...");

        if (File.Exists(specialPlantSavingPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(specialPlantSavingPath, FileMode.Open))
            {
                SpecialPlantData specialPlantData = formatter.Deserialize(stream) as SpecialPlantData;

                Color specialPlantColor = CreateColor(specialPlantData);
                
                specialPlantOnScene.elementIndex = specialPlantData.elementIndex;
                specialPlantOnScene.isTuned = specialPlantData.isTuned;
                specialPlantOnScene.flowerColor = specialPlantColor;

                specialPlantOnScene.Tune();
            }
            Debug.Log("Special plant is loaded!");
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
