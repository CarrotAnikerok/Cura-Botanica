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

        color[0] = specialPlant.flowerColor.r;
        color[1] = specialPlant.flowerColor.g;
        color[2] = specialPlant.flowerColor.b;
        color[3] = specialPlant.flowerColor.a;
    }
}
