using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlantButton : MonoBehaviour, IPointerClickHandler
{
    private GameObject plantMenu;
    public string buttonName;

    void Start()
    {
        plantMenu = GameObject.Find("GameManager").GetComponent<IManager>().plantMenu;
        buttonName = this.name;
    }

    private void Update()
    {   //������ ��� ������ �� ���� �������
        if (!plantMenu.activeSelf)
        {
            this.name = buttonName;
        }
    }

    /// <summary>
    /// ���������� �� ������� ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        OpenPlantMenu();
    }

    /// <summary>
    /// ��������� ���� ��������.
    /// </summary>
    public void OpenPlantMenu()
    {
        this.name = "ActivePlantButton";
        plantMenu.SetActive(true);
    }
}
