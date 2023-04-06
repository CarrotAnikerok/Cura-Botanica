using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlantButton : MonoBehaviour, IPointerClickHandler
{
    private GameObject plantMenu;
    public string buttonName;
    public Plant plant;

    void Start()
    {
        plantMenu = GameObject.Find("GameManager").GetComponent<IManager>().plantMenu;
        buttonName = this.name;

        // Свитч конструкция для связи кнопки с растением объекта. В идеале переделеать, чтобы соблюдался принцип Open closed
        switch (buttonName) 
        {
            case "Aloe Vera Button":
                plant = GetComponent<AloeVera>().plant;
                break;
            case "Cactus Button":
                plant = GetComponent<Cactus>().plant;
                break;
            default:
                Debug.Log(":(");
                break;
        }
    }

    private void Update()
    {   //меняет имя кнопки на свое обычное
        if (!plantMenu.activeSelf)
        {
            this.name = buttonName;
        }
    }

    /// <summary>
    /// Вызывается по нажатия мыши
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
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
