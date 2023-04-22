using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlant : MonoBehaviour
{
    public Plant plant;

    public void Start()
    {
        Debug.Log(plant.name + " " + plant.waterCoefficient);
        plant.Dry();
        Debug.Log(plant.name + " " + plant.waterCoefficient);
    }
}
