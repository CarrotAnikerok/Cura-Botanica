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
        Debug.Log(plantMenu);
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
        OpenPlantMenu();
    }

    public void OpenPlantMenu()
    {
        this.name = "ActivePlantButton";
        plantMenu.SetActive(true);
/*
        plantMenu.transform.localScale = Vector2.zero;
        plantMenu.transform.localPosition = this.transform.localPosition;

        plantMenu.transform.LeanScale(Vector2.one, 0.3f);
        plantMenu.transform.LeanMoveLocal(Vector2.zero, 0.3f);*/
    }
}
