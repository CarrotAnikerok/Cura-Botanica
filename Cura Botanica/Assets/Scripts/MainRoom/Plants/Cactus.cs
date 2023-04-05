using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public Plant plant = new Plant("Cactus");
    void Start()
    {
        Debug.Log(plant.name);
        Debug.Log("Это коэффицент кактуса " + plant.waterCoefficient);
        plant.Dry();
        plant.Dry();
        Debug.Log("Это коэффицент кактуса " + plant.waterCoefficient);
    }
}
