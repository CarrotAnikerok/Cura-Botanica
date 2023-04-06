using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public Plant activePlant;

    /// <summary>
    /// Обеспечивает полив в меню растения
    /// </summary>
    public void WaterActivePlant()
    {
        activePlant.Pour();
        Debug.Log(activePlant.name + activePlant.waterCoefficient);
    }

}
