using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AloeVera : MonoBehaviour
{
    public Plant plant = new("Aloe Vera");
    int normalCoefficent;
    // Алое идеально полито, если в горшке 300 мл. воды (это 1.00 коэффицент)
    // Каждую фазу алое персыхает на 30 мл.
    // За три фазы алое высохнет на 90 мл.
    // За 6 фаз алое высохнет на 180 мл, останется 120 мл.
    // Если в горшке останется меньше, чем 120 мл, растению будет плохо.
    // Если в горше будет больше, чем 300 мл, растению будет плохо.

  /*  public void Pour(int water)
    {
        if (plant.waterCoefficient < 2.0f)
        {
            plant.waterCoefficient += water / normalCoefficent;
        }
    }*/

    void Start()
    {
        Debug.Log("Это коэффицент алое " + plant.waterCoefficient);
        plant.Dry();
        Debug.Log("Это коэффицент алое " + plant.waterCoefficient);
    }
}
