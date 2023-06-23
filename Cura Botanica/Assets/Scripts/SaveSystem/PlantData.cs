using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlantData
{
    public string name;
    public int placeIndex;
    public string state;
    public float waterCoefficient;

    public PlantData(PlantButton plant) {
        this.name = plant.plant.plantName;
        this.placeIndex = plant.placeIndex;
        this.state = plant.plant.state;
        this.waterCoefficient = (float) plant.plant.waterCoefficient;
    }
}
