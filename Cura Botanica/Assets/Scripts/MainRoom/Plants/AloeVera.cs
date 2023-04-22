using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AloeVera : Plant
{
    public override double waterCoefficient
    {
        get { return _waterCoefficient; }
        set { _waterCoefficient = value; }
    }

    public override double normalWaterAmount
    {
        get { return _normalWaterAmount; }
        set { _normalWaterAmount = value; }
    }

    public override string state
    {
        get { return _state; }
        set { _state = value; }
    }

    public override string[] states
    {
        get { return _states; }
        set { _states = value; }
    }

    public AloeVera()
    {
        this.normalWaterAmount = 300f;
        this.waterCoefficient = 1.0f;
        this.state = states[2];
    }

    public override void Dry()
    {
        if (waterCoefficient > 0.0f)
        {
            this.waterCoefficient -= 0.3f;
        }
    }

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
}
