﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class PlantMenu : MonoBehaviour
{
    private PlantButton _plantButton;
    private GameObject _UI;
    private Vector2 _plantButtonPosition;
    private Tools _tools;
    private int stateOfPlant;

    public Image plantImage;
    public Sprite bigSprite;
    public Plant activePlant;
    public CanvasGroup blackBackground;
    public Image state;
    public Sprite[] states = new Sprite[6];
    public Plant[] sortedPlants;
    


    private void Start()
    {
        state = GameObject.Find("State Image").GetComponent<Image>();
        _UI = GameObject.Find("User Interface");
        plantImage = GameObject.Find("Actual Image Of Plant").GetComponent<Image>();
        _tools = gameObject.GetComponent<Tools>();
        gameObject.SetActive(false);

        PlantButton[]  allPlantsButtons = FindObjectsOfType<PlantButton>();
        var allPlants = new List<Plant>();
        foreach (PlantButton plantButton in allPlantsButtons)
        {
            allPlants.Add(plantButton.plant);
        }
        IEnumerable<Plant> plants = allPlants.OrderBy(p => p.placeIndex);
        int i = 0;
        sortedPlants = new Plant[plants.Count<Plant>()];
        foreach (Plant plant in plants)
        {
            sortedPlants[i] = plant;
            i += 1;
        }

    }

    /* Find pressed button, take it image. Tunes plant menu properly and give it animations. */
    private void OnEnable()
    {
        if (GameObject.Find("ActivePlantButton") != null)
        {
            Tune();

            // animations
            blackBackground.gameObject.SetActive(true);
            transform.localScale = Vector2.zero;
            transform.position = _plantButtonPosition;
            Debug.Log("Это позиция открытия" + transform.position);
            blackBackground.alpha = 0;

            transform.LeanScale(Vector2.one, 0.3f);
            transform.LeanMoveLocal(Vector2.zero, 0.3f);
            blackBackground.LeanAlpha(1, 0.2f);
        }

    }

    public void Move()
    {
        _plantButton.name = _plantButton.buttonName;
        int i = Array.FindIndex(sortedPlants, x => x == _plantButton.plant);
        foreach (Plant plant in sortedPlants)
        {
            Debug.Log("Растение и индекс:" + plant + Array.FindIndex(sortedPlants, x => x == plant));
        }
        if (i + 1 == sortedPlants.Length)
        {
            sortedPlants[0].name = "ActivePlantButton";
        }
        else
        {
            sortedPlants[i + 1].name = "ActivePlantButton";
        }
        Tune();
    }


    private void Tune()
    {
        _plantButton = GameObject.Find("ActivePlantButton").GetComponent<PlantButton>();
        _plantButtonPosition = _plantButton.transform.position;

        // Find needed plant
        activePlant = _plantButton.plant;
        _tools.activePlant = activePlant;
        _tools.MakeRightLight();

        stateOfPlant = Array.FindIndex(activePlant.states, x => x == activePlant.state);

        // Change image in needed plant
        bigSprite = activePlant.statesPicturesBig[stateOfPlant];
        plantImage.sprite = bigSprite;

        // Change state sprite
        state.sprite = states[stateOfPlant];
    }


    public void Close()
    {
        transform.LeanMove(_plantButtonPosition, 0.3f);
        blackBackground.LeanAlpha(0, 0.2f);

        transform.LeanScale(Vector2.zero, 0.3f).setOnComplete(OnComplete);
        _UI.SetActive(true);
    }


    private void OnComplete()
    {
        blackBackground.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
