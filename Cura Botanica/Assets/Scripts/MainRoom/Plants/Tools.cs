using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public Plant activePlant;

    /// <summary>
    /// ������������ ����� � ���� ��������
    /// </summary>
    public void WaterActivePlant()
    {
        activePlant.Pour();
        Debug.Log(activePlant.name + activePlant.waterCoefficient);
    }

}
