using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IManager : MonoBehaviour

    // ����� �����, ����� ���������� ����� ����������� ������� � ���������� � ��� ����� IManager,
    // ���� ���� ��� ����������
{
    public GameObject plantMenu;
    public string fase;

    void Awake()
    {
        plantMenu = GameObject.Find("PlantMenu");
    }
}
