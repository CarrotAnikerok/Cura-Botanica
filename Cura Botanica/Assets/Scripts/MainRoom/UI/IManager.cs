using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IManager : MonoBehaviour

    // ����� �����, ����� ���������� ����� ����������� ������� � ���������� � ��� ����� IManager,
    // ���� ���� ��� ����������
{
    public GameObject plantMenu;

    void Awake()
    {
        plantMenu = GameObject.Find("PlantMenu");
        Debug.Log(plantMenu);
    }
}
