using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class FaseButton : MonoBehaviour, IPointerClickHandler
{
    public string[] phases = {"Day", "Evening", "Morning" };
    public Sprite[] phasesPictures = new Sprite[3];

    public Image background;
    public Sprite[] bgPictures = new Sprite[3];

    public Image image;
    public string phase;
    GamePlant[] allPlants;

    public GameObject choiceMenu;

    public Transitions transition;
    public BlackTransition blackTransition;

    public FaseButton()
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
        transition.setDay();
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
        updatePhaseButton(i);

        yield return new WaitForSeconds(endTime);
    }


    void updatePlants()
    {
        foreach (GamePlant plant in allPlants)
        {
            plant.plant.ChangeState();
            plant.plant.Dry();
            Debug.Log(plant.plant.name + " � ��������� " + plant.plant.state + " � �� ���������� " + plant.plant.waterCoefficient);
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
