using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PhaseButton : MonoBehaviour, IPointerClickHandler
{
    public string[] phases = {"Day", "Evening", "Morning" };
    public Sprite[] phasesPictures = new Sprite[3];

    public Image background;
    public Sprite[] bgPictures = new Sprite[3];

    public Image image;
    public string phase;
    GamePlant[] allPlants;

    public GameObject choiceMenu;
    public Handbook handbook;

    public Transitions transition;
    public BlackTransition blackTransition;

    private double normalHumidity = 0.6;

    public PhaseButton()
    {
        this.phase = phases[0];
    }

    public void Awake()
    {
        allPlants = FindObjectsOfType<GamePlant>();
        background = GameObject.Find("Background").GetComponent<Image>();

        image = GetComponent<Image>();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int i = Array.FindIndex(phases, x => x == phase);
        if (i < 2)
        {
            StartCoroutine(LoadPhaseTransition());
            StartCoroutine(LoadUpdate(i, 0.4f, 0.6f));

        }
        else if (i == 2)
        {
            StartCoroutine(LoadDayTransition());
            StartCoroutine(LoadUpdate(i, 1f, 3.5f));
        }

        transition.image.sprite = transition.fase[i];

    }

    IEnumerator LoadPhaseTransition()
    {
        transition.StartTransition();
        yield return new WaitForSeconds(1f);
        transition.ReturnToStart();
    }

    IEnumerator LoadDayTransition()
    {
        blackTransition.StartTransition();
        yield return new WaitForSeconds(1f);
        transition.SetDay();
        choiceMenu.SetActive(true); // move later
        StartCoroutine(blackTransition.FadeTransition());

        yield return new WaitForSeconds(0.4f);
        transition.StartChangeDay();
        yield return new WaitForSeconds(3.5f);

        blackTransition.StartTransition();
        yield return new WaitForSeconds(1f);
        transition.EndChangeDay();
        StartCoroutine(blackTransition.FadeTransition());
    }

    IEnumerator LoadUpdate(int i, float startTime, float endTime)
    {
        yield return new WaitForSeconds(startTime);

        updatePlants();
        Debug.Log("Дневная сейчас будет видна");
        handbook.showNote(1);
        updatePhaseButton(i);

        yield return new WaitForSeconds(endTime);
    }

    void updatePlants()
    {
        foreach (GamePlant plant in allPlants)
        {

            if (plant.plant.waterCoefficient > plant.plant.maxWaterCoefficient)
            {
                //handbook.makeANote(plant.plant.plantName + ": земля выглядит слишком влажной.\n");
            } 
            else if (plant.plant.waterCoefficient < plant.plant.minWaterCoefficient)
            {
                //handbook.makeANote(plant.plant.plantName + ": походу, тут все пересохло.\n");
            }
            plant.plant.ChangeState();
            plant.plant.Dry();
            plant.plant.ChangeHumidityTo(normalHumidity, 0.10f);
            Debug.Log(plant.plant.name + " в состоянии " + plant.plant.state + " и их коэффицент " + plant.plant.waterCoefficient);
        }
    }

    void updatePhaseButton(int i)
    {
        if (i < 2)
        {
            this.phase = phases[i + 1];
            image.sprite = phasesPictures[i + 1];
            background.sprite = bgPictures[i + 1];
        }
        else if (i == 2)
        {
            this.phase = phases[0];
            image.sprite = phasesPictures[0];
            background.sprite = bgPictures[0];
        }
    }
}
