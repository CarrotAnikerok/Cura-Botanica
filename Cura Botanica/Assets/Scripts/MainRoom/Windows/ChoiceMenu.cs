using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceMenu : MonoBehaviour
{
    public GameObject[] plantsForSelection;
    [SerializeField] private GameObject inactivePlants;

    [SerializeField] private GameObject plantForSelection1;
    [SerializeField] private GameObject plantForSelection2;
    [SerializeField] private GameObject plantForSelection3;

    [SerializeField] private Sprite baseSprite;
    private GameObject chosenPlant;

    public TextMeshProUGUI title;

    private void OnEnable()
    {
        plantsForSelection = new GameObject[inactivePlants.transform.childCount];
        for (int i = 0; i < inactivePlants.transform.childCount; i++)
        {
            plantsForSelection[i] = inactivePlants.transform.GetChild(i).gameObject;
        }

        if (plantsForSelection.Length != 0)
            chosenPlant = plantsForSelection[0];

        OfferPlant();
    }

    public void OfferPlant()
    {
        if (plantsForSelection.Length != 0)
        {
            title.text = "Вы получили новое растение: " + chosenPlant.GetComponent<PlantButton>().plant.plantName + "!";
            plantForSelection2.GetComponent<Image>().sprite = chosenPlant.GetComponent<PlantButton>().plant.statesPicturesBig[2];
            ChangeSize(600, 600, plantForSelection2);
            plantForSelection2.transform.localPosition += new Vector3(0, 100);
        } 
        else
        {
            plantForSelection2.transform.localPosition = new Vector3(3.5f, 0); //why are you flying boy, idk
            title.text = "На сегодня новых растений нет :(";
            ChangeSize(350, 400, plantForSelection2);
            plantForSelection2.GetComponent<Image>().sprite = baseSprite;
            plantForSelection1.SetActive(true);
            plantForSelection3.SetActive(true);
        }
    }

    public void AcceptPlant()
    {
        GameObject greed = GameObject.Find("Grid");
        for (int i = 0; i < greed.transform.childCount; i++)
        {
            if (greed.transform.GetChild(i).transform.childCount == 0)
            {
                chosenPlant.transform.SetParent(greed.transform.GetChild(i));
                chosenPlant.GetComponent<PlantButton>().placeIndex = greed.transform.GetChild(i).GetComponent<PlantSlot>().placeIndex;
                chosenPlant.transform.localScale = new Vector3(2.2f, 2.2f, 1); // scale dont working, i dont know why, my head is hurt :(
                break;
            }
        }
    }

    private void ChangeSize(int width, int height, GameObject gameObject)
    {
        RectTransform size = gameObject.GetComponent<RectTransform>();
        size.sizeDelta = new Vector2(width, height);
    }
}


