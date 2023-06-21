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
    public string currentPhase;
    public string nextPhase;
    PlantButton[] allPlants;

    public GameObject choiceMenu;
    public Handbook handbook;

    public Transitions transition;
    public BlackTransition blackTransition;

    private double normalHumidity = 0.6;

    public PhaseButton()
    {
        this.currentPhase = phases[2];
        this.nextPhase = phases[0];
    }

    public void Awake()
    {
        allPlants = FindObjectsOfType<PlantButton>();
        background = GameObject.Find("Background").GetComponent<Image>();

        image = GetComponent<Image>(); // Image of what?

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int i = Array.FindIndex(phases, x => x == nextPhase);

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
        FindObjectOfType<AudioManager>().Play("Crickets");
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
        // savePlantsProps();
        handbook.showNote(nextPhase);
        updatePhaseButton(i);

        yield return new WaitForSeconds(endTime);
    }

    void updatePlants()
    {
        foreach (PlantButton plant in allPlants)
        {

            if (plant.plant.waterCoefficient > plant.plant.maxWaterCoefficient)
            {
                //handbook.makeANote(plant.plant.plantName + ": ����� �������� ������� �������.\n");
            } 
            else if (plant.plant.waterCoefficient < plant.plant.minWaterCoefficient)
            {
                //handbook.makeANote(plant.plant.plantName + ": ������, ��� ��� ���������.\n");
            }
            plant.plant.ChangeState();
            plant.plant.Dry();
            plant.plant.ChangeHumidityTo(normalHumidity, 0.10f);
            Debug.Log(plant.plant.name + " � ��������� " + plant.plant.state + " � �� ���������� " + plant.plant.waterCoefficient);
        }
    }

/*Where to load...*/
    void savePlantsProps() {
        string plantsProps = "";

        foreach (PlantButton plant in allPlants)
        {
            plantsProps += plant.plant.plantName + ", " + plant.plant.state + ", " + plant.plant.waterCoefficient + " / "; // Really want to add slot index
        }

        PlayerPrefs.SetString("PlantsProperties", plantsProps);
    }

    void updatePhaseButton(int i)
    {
        if (i < 2)
        {
            this.nextPhase = phases[i + 1];
            this.currentPhase = phases[i];
            image.sprite = phasesPictures[i + 1];
            background.sprite = bgPictures[i + 1];
        }
        else if (i == 2)
        {
            this.nextPhase = phases[0];
            this.currentPhase = phases[2];
            image.sprite = phasesPictures[0];
            background.sprite = bgPictures[0];
           
        }


    }
}
