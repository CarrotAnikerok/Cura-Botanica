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
<<<<<<< Updated upstream
=======
        image = GetComponent<Image>();

>>>>>>> Stashed changes
    }

    public void OnPointerClick(PointerEventData eventData)
    {
<<<<<<< Updated upstream
=======
        StartCoroutine(LoadUpdate());
    }

    IEnumerator LoadUpdate()
    {
        transition.StartTransition();
        yield return new WaitForSeconds(0.2f);

>>>>>>> Stashed changes
        int i = Array.FindIndex(fases, x => x == fase);
        if (i < 2)
        {
            this.fase = fases[i + 1];
<<<<<<< Updated upstream
        } 
=======
            image.sprite = fasesPictures[i + 1];
            
        }
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        Debug.Log(fase);
=======
        transition.EndTransition();
        yield return new WaitForSeconds(0.5f);
        transition.ReturnToStart();
        transition.image.sprite = transition.fases[i];
>>>>>>> Stashed changes
    }
}
