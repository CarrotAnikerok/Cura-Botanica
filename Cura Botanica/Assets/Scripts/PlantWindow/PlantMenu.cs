using System.Collections;
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
    private int _stateOfPlant;
    private PMHandbook _handbook; // в идеале здесь быть не должно, но завтра дедлайн

    public Image plantImage;
    public Sprite bigSprite;
    public Plant activePlant;
    public CanvasGroup blackBackground;
    public Image state;
    public Sprite[] states = new Sprite[6];
    public PlantButton[] sortedPlants;

    private void Start()
    {
        state = GameObject.Find("State Image").GetComponent<Image>();
        _UI = GameObject.Find("User Interface");
        _handbook = GameObject.Find("PM Handbook").GetComponent<PMHandbook>();
        plantImage = GameObject.Find("Actual Image Of Plant").GetComponent<Image>();
        _tools = gameObject.GetComponent<Tools>();
        gameObject.SetActive(false);
    }

    /* Find pressed button, take it image. Tunes plant menu properly and give it animations. */
    private void OnEnable()
    {
        UpdateSortedButtons();
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

    public void MoveForward()
    {
        _plantButton.name = _plantButton.buttonName;
        int i = Array.FindIndex(sortedPlants, x => x == _plantButton);
        foreach (PlantButton plant in sortedPlants)
        {

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

    public void MoveBackward()
    {
        _plantButton.name = _plantButton.buttonName;
        int i = Array.FindIndex(sortedPlants, x => x == _plantButton);

        if (i == 0)
        {
            sortedPlants[sortedPlants.Length - 1].name = "ActivePlantButton";
        }
        else
        {
            sortedPlants[i - 1].name = "ActivePlantButton";
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

        _stateOfPlant = Array.FindIndex(activePlant.states, x => x == activePlant.state);

        // Change image in needed plant
        bigSprite = activePlant.statesPicturesBig[_stateOfPlant];
        plantImage.sprite = bigSprite;

        // Change state sprite
        state.sprite = states[_stateOfPlant];

        _handbook.getPlantDescription(activePlant.plantName);
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

    private void UpdateSortedButtons()
    {
        PlantButton[] allPlantsButtons = FindObjectsOfType<PlantButton>();
        List<PlantButton> allPlants = new List<PlantButton>();
        int i = 0;

        foreach (PlantButton plantButton in allPlantsButtons)
        {
            if (plantButton.placeIndex != 0)
            {
                allPlants.Add(plantButton);
            }
        }

        IEnumerable<PlantButton> plants = allPlants.OrderBy(p => p.placeIndex);
        sortedPlants = new PlantButton[plants.Count<PlantButton>()];

        foreach (PlantButton plant in plants)
        {
            sortedPlants[i] = plant;
            i += 1;
        }
    }
}
