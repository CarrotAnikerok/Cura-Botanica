using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IManager : MonoBehaviour

    // ����� �����, ����� ���������� ����� ����������� ������� � ���������� � ��� ����� IManager,
    // ���� ���� ��� ����������
{
    public GameObject plantMenu;
    public GameObject UI;

    void Awake()
    {
        plantMenu = GameObject.Find("PlantMenu");
        UI = GameObject.Find("UserInterface");
    }
}
