using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instuments : MonoBehaviour
{
    public Plant activePlant;

    public void OnEnable()
    {
        activePlant = GetComponent<PlantMenu>().activePlant;
        Debug.Log(activePlant);
    }

    public void WaterActivePlant()
    {
        activePlant.Pour();
        Debug.Log(activePlant.waterCoefficient);
    }

}
