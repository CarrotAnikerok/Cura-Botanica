using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlantButton : MonoBehaviour, IPointerClickHandler
{
    private GameObject plantMenu;
    public string buttonName;
    public Plant plant;
    public GameObject UI;
    public int placeIndex;

    void Start()
    {
        UI = GameObject.Find("User Interface");
        plantMenu = GameObject.Find("GameManager").GetComponent<IManager>().plantMenu;
        buttonName = this.name;

    }

    private void Update()
    {   
        if (!plantMenu.activeSelf)
        {
            this.name = buttonName;
        }
    }

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


    public void OpenPlantMenu()
    {
        this.name = "ActivePlantButton";
        plantMenu.SetActive(true);
    }
}
