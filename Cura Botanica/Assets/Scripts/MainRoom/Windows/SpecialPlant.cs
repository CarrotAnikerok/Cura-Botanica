using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpecialPlant : MonoBehaviour
{
    [SerializeField] private Sprite[] backgrounds = new Sprite[4];
    [SerializeField] private Sprite[] plants = new Sprite[4];
    [SerializeField] private Sprite[] buttons = new Sprite[4];
    [SerializeField] private GameObject[] flowers = new GameObject[4];

    [SerializeField] private Image background;
    [SerializeField] private Image plant;
    [SerializeField] public GameObject flower;
    [SerializeField] private Image button;

    [SerializeField]  private TMP_Dropdown dayDropdown;
    [SerializeField]  private TMP_Dropdown monthDropdown;
    [SerializeField]  private TMP_Dropdown yearDropdown;

    private int day;
    private int month;
    private int year;

    [HideInInspector]
    public int elementIndex;
    [HideInInspector]
    public bool isTuned = false;
    [HideInInspector]
    public Color flowerColor;


    public void Tune()
    {
        if (!isTuned)
        {
            day = dayDropdown.value;
            month = monthDropdown.value;
            year = yearDropdown.value;

            elementIndex = chooseElement();
            flowerColor = chooseColor();
        }
       
        background.sprite = backgrounds[elementIndex];
        plant.sprite = plants[elementIndex];
        button.sprite = buttons[elementIndex];
        flower = flowers[elementIndex];
        flower.SetActive(true);

        flower.GetComponent<Image>().color = flowerColor;

        isTuned = true;
    }

    private int chooseElement()
    {
        if (month == 11 || month <= 1 ) // winter - water
        {
            return 1;
        }
        else if ( month > 1 && month <= 4) // spring - earth
        {
            return 0;
        }
        else if (month > 4 && month <= 7) // summer - fire
        {
            return 0;
        }
        else if (month > 7 && month <= 10) // autumn - wind
        {
            return 1;
        }

        return 0;
    }

    private Color chooseColor()
    {
        int color = year % 10;
        switch (color) {
            case 1:
                return new Color(0.6f, 0f, 0f, 1f); //red
            case 2:
                return new Color(1f, 1f, 0.4f, 1f); //yellow
            case 3:
                return new Color(0.6f, 0.6f, 1f, 1f); //light-blue
            case 4:
                return Color.white;
            case 5:
                return new Color(0.6f, 1f, 1f, 1f);  //cyan
            case 6:
                return new Color(1f, 0.6f, 0.8f, 1f); //pink
            case 7:
                return new Color(0.2f, 0.4f, 0.6f, 1f); //blue
            case 8:
                return new Color(0.4f, 0.2f, 0.8f, 1f); //purple
            case 9:
                return new Color(1f, 0.4f, 0f, 1f); //orange
            case 0:
                return new Color(0.6f, 0.6f, 1f, 1f); //light-blue change later
        }
        return Color.white;
    }
}
