using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class FaseButton : MonoBehaviour, IPointerClickHandler
{
    public string[] fases = {"Day", "Evening", "Morning" };
    public Sprite[] fasesPictures = new Sprite[3];
    public Image image;
    public string fase;
    GamePlant[] allPlants;

    public Transitions transition;

    public FaseButton()
    {
        this.fase = fases[0];
    }

    public void Awake()
    {
        allPlants = FindObjectsOfType<GamePlant>();
        Debug.Log(transition);
        image = GetComponent<Image>();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(LoadUpdate());
        StartCoroutine(LoadTransition());
    }

    IEnumerator LoadTransition()
    {
        transition.StartTransition();
        yield return new WaitForSeconds(1f);
        transition.ReturnToStart();
    }

    IEnumerator LoadUpdate()
    {
        yield return new WaitForSeconds(0.5f);

        int i = Array.FindIndex(fases, x => x == fase);
        if (i < 2)
        {
            this.fase = fases[i + 1];
            image.sprite = fasesPictures[i + 1];
        }
        else if (i == 2)
        {
            this.fase = fases[0];
            image.sprite = fasesPictures[0];
        }

        foreach (GamePlant plant in allPlants)
        {
            plant.plant.ChangeState();
            plant.plant.Dry();
            Debug.Log(plant.plant.name + " � ��������� " + plant.plant.state);
        }

        yield return new WaitForSeconds(0.5f);
        transition.image.sprite = transition.fase[i];

    }
}
