using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpecialPlantData
{
    public int elementIndex;
    public float[] color = new float[4];
    public bool isTuned;

    public SpecialPlantData(SpecialPlant specialPlant) {
        this.elementIndex = specialPlant.elementIndex;
        this.isTuned = specialPlant.isTuned;

        color[0] = specialPlant.flowerColor.a;
        color[1] = specialPlant.flowerColor.r;
        color[2] = specialPlant.flowerColor.g;
        color[3] = specialPlant.flowerColor.b;
    }
}
