using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class FaseButton : MonoBehaviour, IPointerClickHandler
{
    public string[] fases = {"Morning", "Day", "Evening"};
    public string fase;
    GamePlant[] allPlants;

    public FaseButton()
    {
        this.fase = fases[0];
    }

    public void Awake()
    {
        allPlants = FindObjectsOfType<GamePlant>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int i = Array.FindIndex(fases, x => x == fase);
        if (i < 2)
        {
            this.fase = fases[i + 1];
        } 
        else if (i == 2)
        {
            this.fase = fases[0]; 
        }

        foreach(GamePlant plant in allPlants)
        {
            plant.plant.ChangeState();
            plant.plant.Dry();
            Debug.Log(plant.plant.name + " в состоянии " + plant.plant.state);
        }

        Debug.Log(fase);
    }
}
