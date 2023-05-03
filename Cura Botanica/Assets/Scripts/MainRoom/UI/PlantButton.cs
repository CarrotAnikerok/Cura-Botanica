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
        plant = GetComponent<GamePlant>().plant;

    }

    private void Update()
    {   //меняет имя кнопки на свое обычное
        if (!plantMenu.activeSelf)
        {
            this.name = _buttonName;
        }
    }

    /// <summary>
    /// Вызывается по нажатия мыши
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            return;
        }

        UI.SetActive(false);
        OpenPlantMenu();
    }

    /// <summary>
    /// Открывает меню растения.
    /// </summary>
    public void OpenPlantMenu()
    {
        this.name = "ActivePlantButton";
        plantMenu.SetActive(true);
    }
}
