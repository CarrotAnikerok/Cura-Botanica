using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    static string savingPath = Application.persistentDataPath + "/plant.save";

    public static void SavePlants (PlantButton[] existingPlants)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(savingPath, FileMode.Create);

        foreach (PlantButton plant in existingPlants)
        {
            PlantData existingPlantsData = new PlantData(plant);

            formatter.Serialize(stream, existingPlantsData);
        }
        
        stream.Close();
    }

    public static PlantButton[] LoadPlants ()
    {
        if (File.Exists(savingPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savingPath, FileMode.Open);

            PlantData[] savedPlantsData = formatter.Deserialize(stream) as PlantData[];
            stream.Close();

            int plantNumber = savedPlantsData.Length;
            PlantButton[] savedPlants = new PlantButton[plantNumber];

            for (int i = 0; i < plantNumber; i++)
            {
                savedPlants[i].plant.plantName = savedPlantsData[i].name;
                savedPlants[i].plant.state = savedPlantsData[i].state;
                savedPlants[i].plant.waterCoefficient = savedPlantsData[i].waterCoefficient;
            }
            
            return savedPlants;

        } else
        {
            Debug.LogError("Save file not found in " + savingPath);
            return null;
        }
    }
    
}
