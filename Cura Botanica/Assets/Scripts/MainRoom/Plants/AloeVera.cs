using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AloeVera : MonoBehaviour
{
    public Plant plant = new("Aloe Vera");
    void Start()
    {
        Debug.Log("Это коэффицент алое " + plant.waterCoefficient);
        plant.Dry();
        Debug.Log("Это коэффицент алое " + plant.waterCoefficient);
    }
}
