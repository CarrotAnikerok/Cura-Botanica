using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpecialPlantData
{
    public bool isTuned;

    public SpecialPlantData(SpecialPlant specialPlant) {
        this.isTuned = specialPlant.isTuned;
    }
}
