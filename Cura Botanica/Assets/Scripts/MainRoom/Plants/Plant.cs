using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant
{
    public string name;
    public double waterCoefficient;
    public Plant(string name)
    {
        this.name = name;
        this.waterCoefficient = 1.0f;
    }

    public void Dry()
    {
        if (waterCoefficient > 0.0f)
        {
            this.waterCoefficient -= 0.25f;
        }
    }

    public void Pour()
    {
        if (waterCoefficient < 2.0f)
        {
            this.waterCoefficient += 0.25f;
        }
    }
}
