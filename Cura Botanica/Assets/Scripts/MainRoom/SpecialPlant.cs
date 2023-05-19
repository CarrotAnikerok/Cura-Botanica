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

    [SerializeField] private Image background;
    [SerializeField] private Image plant;
    [SerializeField] private Image flover;
    [SerializeField] private Image button;

    [SerializeField]  private TMP_Dropdown dayDropdown;
    [SerializeField]  private TMP_Dropdown monthDropdown;
    [SerializeField]  private TMP_Dropdown yearDropdown;

    private int day;
    private int month;
    private int year;

    public void Tune()
    {
        day = dayDropdown.value;
        month = monthDropdown.value;
        year = yearDropdown.value;

        int element = chooseElement();
        background.sprite = backgrounds[element];
        plant.sprite = plants[element];
        button.sprite = buttons[element];


        plant.color = chooseColor();
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
                return new Color(1f, 0.22f, 0.2f, 1f);
            case 2:
                return Color.yellow;
        }

        return Color.white;
    }
}
