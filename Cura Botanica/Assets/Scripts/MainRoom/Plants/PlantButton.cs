using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlantButton : MonoBehaviour, IPointerClickHandler
{
    private GameObject plantMenu;
    public string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        plantMenu = GameObject.Find("GameManager").GetComponent<IManager>().plantMenu;
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
