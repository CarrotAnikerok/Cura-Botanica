using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public Plant cactus = new Plant("Cactus");
    void Start()
    {
        Debug.Log(cactus.name);
        Debug.Log("��� ���������� ������� " + cactus.waterCoefficient);
        cactus.Dry();
        cactus.Dry();
        Debug.Log("��� ���������� ������� " + cactus.waterCoefficient);
    }
}
