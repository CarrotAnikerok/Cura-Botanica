using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlantButton : MonoBehaviour, IPointerClickHandler
{
    private GameObject plantMenu;
    private string _buttonName;
    public Plant plant;
    public GameObject UI;

    void Start()
    {
        UI = GameObject.Find("User Interface");
        plantMenu = GameObject.Find("GameManager").GetComponent<IManager>().plantMenu;
        _buttonName = this.name;
        //plant = GetComponent<GamePlant>().plant;

    }

    private void Update()
    {   //������ ��� ������ �� ���� �������
        if (!plantMenu.activeSelf)
        {
            this.name = _buttonName;
        }
    }

    /// <summary>
    /// ���������� �� ������� ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("SlideClick");
        if (eventData.dragging)
        {
            return;
        }

        UI.SetActive(false);
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
