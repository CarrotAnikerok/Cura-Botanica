using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public Plant plant = new Plant("Cactus");
    void Start()
    {
        Debug.Log(plant.name);
        Debug.Log("��� ���������� ������� " + plant.waterCoefficient);
        plant.Dry();
        plant.Dry();
        Debug.Log("��� ���������� ������� " + plant.waterCoefficient);
    }
}
