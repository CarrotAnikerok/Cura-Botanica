using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AloeVera : MonoBehaviour
{
    public Plant aloeVera = new Plant("Aloe Vera");
    public string plantName;
    void Start()
    {
        plantName = aloeVera.name;
        Debug.Log(plantName);
        Debug.Log("��� ���������� ���� " + aloeVera.waterCoefficient);
        aloeVera.Dry();
        Debug.Log("��� ���������� ���� " + aloeVera.waterCoefficient);
    }
}
