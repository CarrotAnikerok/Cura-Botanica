using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    PlantButton[] plants;
    // Start is called before the first frame update
    void Start()
    {
        //LoadPlants();
    }

    public void LoadPlants() {
        PlantProperties[] plantsData = extractSavingData();

        for(int i = 0; i < plantsData.Length; i++) {
            plants[i].plant.plantName = plantsData[i].name;
            plants[i].plant.state = plantsData[i].state;
            plants[i].plant.waterCoefficient = Convert.ToDouble(plantsData[i].waterCoefficient);
        }
    }

    public class PlantProperties {
        public string name;
        public string state;
        public string waterCoefficient;
        public PlantProperties(string [] props) {
            this.name = props[0];
            this.state = props[1];
            this.waterCoefficient= props[2];
        }
    }

    public PlantProperties[] extractSavingData() {
        string plantSavingString = PlayerPrefs.GetString("PlantsProperties");
        string[] plantsPropertiesString = plantSavingString.Split(" / ");
        int plantsNumber = plantsPropertiesString.Length;
        PlantProperties[] extractedData = new PlantProperties[plantsNumber];

        for (int i = 0; i < plantsNumber; i++) {
            PlantProperties extractedPlant = new PlantProperties(plantsPropertiesString[i].Split(", "));
            extractedData[i] = extractedPlant;
        }
        return extractedData;
    }
}