using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant
{
    public string name;
    public double normalWaterAmount; // при этом количечстве воды в горшке коэффицент будет равен 0.
    public double waterCoefficient;
    public string state;
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

    public void Pour(double waterAmount)
    {
        if (this.waterCoefficient + waterAmount / normalWaterAmount > 2.0f)
        {
            this.waterCoefficient = 2.0f;
        }
        else
        {
            this.waterCoefficient += waterAmount / normalWaterAmount;
        }
    }
}
