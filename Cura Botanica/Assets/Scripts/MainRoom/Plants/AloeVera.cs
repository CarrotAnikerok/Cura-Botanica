using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AloeVera : MonoBehaviour
{
    public Plant plant = new("Aloe Vera");
    // ���� �������� ������, ���� � ������ 300 ��. ���� (��� 1.00 ����������)
    // ������ ���� ���� ��������� �� 30 ��.
    // �� ��� ���� ���� �������� �� 90 ��.
    // �� 6 ��� ���� �������� �� 180 ��, ��������� 120 ��.
    // ���� � ������ ��������� ������, ��� 120 ��, �������� ����� �����.
    // ���� � ����� ����� ������, ��� 300 ��, �������� ����� �����.
    // ����������, ���� ������ ��� ������������ 0.4 - 1.0

  /*  public void Pour(int water)
    {
        if (plant.waterCoefficient < 2.0f)
        {
            plant.waterCoefficient += water / normalCoefficent;
        }
    }*/

    void Start()
    {
        plant.normalWaterAmount = 300f;
        Debug.Log("��� ���������� ���� " + plant.waterCoefficient);
        plant.Dry();
        Debug.Log("��� ���������� ���� " + plant.waterCoefficient);
    }
}
