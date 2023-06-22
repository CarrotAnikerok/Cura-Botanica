using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    static string savingPath = Application.persistentDataPath + "/plant.save";

    public static void SavePlants (PlantButton[] existingPlants)
    {
        Debug.LogWarning("Saving...");
        int plantsNumber = existingPlants.Length;
        
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(savingPath, FileMode.Create))
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

    public static PlantButton[] LoadPlants ()
    {

        Debug.LogWarning("Loading...");

        if (File.Exists(savingPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(savingPath, FileMode.Open)) 
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
            Debug.LogError("Save file not found in " + savingPath);
            return null;
        }
    }

    static GameObject CreateButtonObject(string plantName)
    {
        GameObject buttonObject = new GameObject("ButtonObject");
        buttonObject.AddComponent<PlantButton>();
        buttonObject.AddComponent<DraggableItem>();
        // buttonObject.AddComponent<>(); // Don't understand how to add script of particular plant like "Aloe Vera"

        return buttonObject;
    }
}
